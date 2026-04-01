using Models;
using Models.Enums;
using RepositoryContracts;
using ServicesContracts.AttendanceContracts;
using ServicesContracts.DTOs.AttendancesDTOs;
using ServicesContracts.DTOs.Mappings;
using static Models.Enums.LeaveRequestOptions;

namespace Services.AttendanciesServieces
{
    public class AttendanceUpdaterService : IAttendanceUpdaterService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public AttendanceUpdaterService(IAttendanceRepository attendanceRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            _attendanceRepository = attendanceRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<AttendanceResponse> UpdateAttendance(AttendanceUpdateRequest AttendanceUpdateRequest)
        {
            //check if the AttendanceUpdateRequest is null
            if (AttendanceUpdateRequest is null)
                throw new ArgumentNullException(nameof(AttendanceUpdateRequest), "Department ID is invalid");

            var Attendance = AttendanceUpdateRequest.ToAttendance();
            var leaves = await _leaveRequestRepository.GetAllLeaveRequestsByEmployeeId(AttendanceUpdateRequest.EmployeeId);

            // Determine the attendance status based on the check-in time
            if (leaves.Any(l =>
            AttendanceUpdateRequest.Date >= l.FromDate &&
            AttendanceUpdateRequest.Date <= l.ToDate &&
            l.Status == LeaveStatus.ApprovedByHR))
            {
                Attendance.Status = AttendanceStatus.OnLeave;
            }
            else if (Attendance.CheckInTime is null)
                Attendance.Status = AttendanceStatus.Absent;
            else if (Attendance.CheckInTime > new TimeSpan(9, 15, 0))
                Attendance.Status = AttendanceStatus.Late;
            else
                Attendance.Status = AttendanceStatus.Present;

            // Update the element if exists
            var UpdatedAttendance= await _attendanceRepository.UpdateAttendance(Attendance);
                        
            // Return the attendance response
            return UpdatedAttendance.ToAttendanceResponse();
        }
    }
}
