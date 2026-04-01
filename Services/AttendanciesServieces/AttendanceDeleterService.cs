using RepositoryContracts;
using ServicesContracts.AttendanceContracts;

namespace Services.AttendanciesServieces
{
    public class AttendanceDeleterService : IAttendanceDeleterService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceDeleterService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task DeleteAttendance(Guid id)
        {
            //Check if the provided ID is empty and throw an exception if it is
            if (id== Guid.Empty)
            {
                throw new ArgumentException("Department ID is invalid.", nameof(id));
            }           

            // Call the repository method to delete the attendance 
            await _attendanceRepository.DeleteAttendance(id); ;

        }
    }
}
