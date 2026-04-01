using Models;
using RepositoryContracts;
using ServicesContracts.AttendanceContracts;
using ServicesContracts.DTOs.AttendancesDTOs;
using ServicesContracts.DTOs.Mappings;

namespace Services.AttendanciesServieces
{
    public class AttendanceGetterService : IAttendanceGetterService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceGetterService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public async Task<List<AttendanceResponse>> GetAllAttendances(Guid EmployeeId)
        {
            //Check if the EmployeeId is null
            if (EmployeeId == Guid.Empty)
                throw new ArgumentException("Department ID is invalid.", nameof(EmployeeId));

            // Call the repository method to get all attendance for the given EmployeeId
            var attendances = await _attendanceRepository.GetAttendanciesByEmployeeId(EmployeeId);

            return attendances.Select(attendance => attendance.ToAttendanceResponse()).ToList();

        }

        public async Task<AttendanceResponse?> GetById(Guid id)
        {
            //Check if the Attendance Id is null
            if (id == Guid.Empty)
                throw new ArgumentException("Department ID is invalid.", nameof(id));

            // Call the repository method to get the attendance by its ID
            Attendance? attendance = await _attendanceRepository.GetAttendance(id);

            // Convert the attendance to an AttendanceResponse object and return it
            return attendance?.ToAttendanceResponse();

        }
    }
}
