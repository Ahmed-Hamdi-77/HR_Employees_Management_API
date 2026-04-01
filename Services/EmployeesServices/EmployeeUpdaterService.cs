using RepositoryContracts;
using ServicesContracts.DTOs.DepartmentsDTOs;
using ServicesContracts.DTOs.EmployeesDTOs;
using ServicesContracts.DTOs.Mappings;
using ServicesContracts.EmployeeContracts;

namespace Services.AttendanciesServieces
{
    public class EmployeeUpdaterService : IEmployeeUpdaterService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUpdaterService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        

        public async Task<EmployeeResponse> UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            //Check if EmployeeUpdateRequest is null
            if (employeeUpdateRequest is null)
                throw new ArgumentNullException("Employee update request cannot be null.", nameof(employeeUpdateRequest));

            //Mapping
            var employee = employeeUpdateRequest.ToEmployee();

            //Update the object
            var UpdatedEmployee= await _employeeRepository.UpdateEmployee(employee);

            //Return updated object as employee response
            return UpdatedEmployee.ToEmployeeResponse();
        }
    }
}
