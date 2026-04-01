using Models;
using RepositoryContracts;
using ServicesContracts.DTOs.EmployeesDTOs;
using ServicesContracts.DTOs.Mappings;
using ServicesContracts.EmployeeContracts;

namespace Services.AttendanciesServieces
{
    public class EmployeeGetterService : IEmployeeGetterService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeGetterService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeResponse>> GetAllEmployees()
        {
            // Get all employees from the repository
            List<Employee> employees= await _employeeRepository.GetAllEmployees();

            // Convert the list of Employee objects to a list of EmployeeResponse objects and return it
            return employees.Select(e => e.ToEmployeeResponse()).ToList();
        }

        public async Task<EmployeeResponse> GetById(Guid id)
        {
            // Check if the provided ID is null and throw an exception if it is
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Employee ID is invalid.", nameof(id));
            }

            // Call the repository method to get the employee by its ID and check if the employee is null
            var employee =await _employeeRepository.GetEmployeeById(id) ?? throw new KeyNotFoundException("Employee is not found");

            // Convert the employee to an EmployeeResponse object and return it
            return employee.ToEmployeeResponse();

        }
    }
}
