using RepositoryContracts;
using ServicesContracts.EmployeeContracts;

namespace Services.AttendanciesServieces
{
    public class EmployeeDeleterService : IEmployeeDeleterService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDeleterService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task DeleteEmployee(Guid id)
        {
            // Check if the provided ID is null and throw an exception if it is
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Employee ID is invalid.", nameof(id));
            }

            //Remove the employee with the specified ID 
            await _employeeRepository.DeleteEmployee(id);

        }
    }
}
