using Models;
using Models.Enums;
using RepositoryContracts;
using ServicesContracts.AttendanceContracts;
using ServicesContracts.DTOs.AttendancesDTOs;
using ServicesContracts.DTOs.Mappings;
using System.Runtime.InteropServices;
using static Models.Enums.LeaveRequestOptions;

namespace Services.AttendanciesServieces
{
    public class AttendanceAdderService : IAttendanceAdderService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public AttendanceAdderService(IAttendanceRepository attendanceRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            _attendanceRepository = attendanceRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<AttendanceResponse> AddAttendance(AttendanceAddRequest attendanceAddRequest)
        {
            // Check if the attendanceAddRequest is null
            ArgumentNullException.ThrowIfNull(attendanceAddRequest);

            // Get existing attendances for the same employee from the repository
            var Attendancies = await _attendanceRepository.GetAttendanciesByEmployeeId(attendanceAddRequest.EmployeeId);
            // Get existing leave requests for the same employee from the repository
            var leaves = await _leaveRequestRepository.GetAllLeaveRequestsByEmployeeId(attendanceAddRequest.EmployeeId);


            // Check if attendance already recorded for the employee on the given date
            if (Attendancies.Any(a=>a.Date==attendanceAddRequest.Date))
                throw new InvalidOperationException("Attendance already recorded for this date.");

            AttendanceStatus status;

            // Check if the employee is on leave on the given date
            if (leaves.Any(l =>
            attendanceAddRequest.Date >= l.FromDate &&
            attendanceAddRequest.Date <= l.ToDate &&
            l.Status == LeaveStatus.ApprovedByHR))
            {
                status = AttendanceStatus.OnLeave;
            }
            else if(attendanceAddRequest.CheckInTime> new TimeSpan(9,15,0))
            {
                status = AttendanceStatus.Late;
            }
            else if (attendanceAddRequest.CheckInTime is null)
            {
                status = AttendanceStatus.Absent;
            }
            else
            {
                status = AttendanceStatus.Present;
            }

            //Convert the AttendanceAddRequest to an Attendance object
            Attendance attendance = attendanceAddRequest.ToAttendance();

            // Generate a new AttendanceId for the attendance and set the status
            attendance.Id = Guid.NewGuid();
            attendance.Status = status;

            // Save the attendance to the data store using the repository
            var AddedAttendance= await _attendanceRepository.SaveAttendance(attendance);

            return AddedAttendance.ToAttendanceResponse();
        }
    }
}
