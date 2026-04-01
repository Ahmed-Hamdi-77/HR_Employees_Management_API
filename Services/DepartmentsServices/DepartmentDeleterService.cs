using RepositoryContracts;
using ServicesContracts.DepartmentContracts;

namespace Services.AttendanciesServieces
{
    public class DepartmentDeleterService : IDepartmentDeleterService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentDeleterService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task DeleteDepartment(Guid id)
        {
            //Check if the provided ID is null and throw an exception if it is
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Department ID is invalid.", nameof(id));
            }

            // Call the repository method to delete the department
             await _departmentRepository.DeleteDepartment(id);
        }
    }
}
