using ServicesContracts.DTOs.EmployeesDTOs;

namespace ServicesContracts.EmployeeContracts
{
    public interface IEmployeeAdderService
    {
        /// <summary>
        /// Adds a new Employee
        /// </summary>
        /// <param name="employeeAddRequest"></param>
        /// <returns>Returns the created employee object </returns>

        Task<EmployeeResponse> AddEmployee(EmployeeAddRequest employeeAddRequest);
    }
}
