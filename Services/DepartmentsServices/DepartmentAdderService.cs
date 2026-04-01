using Models;
using Repository;
using RepositoryContracts;
using ServicesContracts.DepartmentContracts;
using ServicesContracts.DTOs.AttendancesDTOs;
using ServicesContracts.DTOs.DepartmentsDTOs;
using ServicesContracts.DTOs.Mappings;

namespace Services.AttendanciesServieces
{
    public class DepartmentAdderService : IDepartmentAdderService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentAdderService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentResponse> AddDepartment(DepartmentAddRequest DepartmentAddRequest)
        {
            // Check if the attendanceAddRequest is null
            ArgumentNullException.ThrowIfNull(DepartmentAddRequest);

            //Convert the DepartmentAddRequest to a Department object
            Department department = DepartmentAddRequest.ToDepartment();

            // Generate a new AttendanceId for the attendance
            department.Id = Guid.NewGuid();

            // Save the department to the data store using the repository
            var AddedDepartment= await _departmentRepository.AddDepartment(department);

            return  AddedDepartment.ToDepartmentResponse();
        }
    }
}
