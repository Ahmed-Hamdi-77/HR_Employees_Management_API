using RepositoryContracts;
using ServicesContracts.DTOs.EmployeesDTOs;
using ServicesContracts.DTOs.Mappings;
using ServicesContracts.EmployeeContracts;

namespace Services.AttendanciesServieces
{
    public class EmployeeAdderService : IEmployeeAdderService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeAdderService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> AddEmployee(EmployeeAddRequest employeeAddRequest)
        {
            // Check if the employeeAddRequest is null
            ArgumentNullException.ThrowIfNull(employeeAddRequest);

            // Convert the EmployeeAddRequest to an Employee object
            var employee = employeeAddRequest.ToEmployee();

            // Generate a new EmployeeId for the employee
            employee.Id = Guid.NewGuid();

            // Save the employee to the data store using the repository
            var addedEmployee = await _employeeRepository.AddEmployee(employee);

            return addedEmployee.ToEmployeeResponse();
        }
    }
}
