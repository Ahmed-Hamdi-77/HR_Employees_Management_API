using Models;
using System;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Employee entity
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Adds an Employee object to the data store
        /// </summary>
        /// <param name="employee">Employee object to add</param>
        /// <returns>Returns the employee object after adding it 
        /// the table</returns>
        Task<Employee> AddEmployee(Employee employee);
        /// <summary>
        /// Returns all Employees in the data store
        /// </summary>
        /// <returns>List of employee objects from table</returns>
        Task<List<Employee>> GetAllEmployees();
        /// <summary>
        /// Returns an employee object based on the given employee id
        /// </summary>
        /// <param name="employeeId">EmployeeId (guid) to search</param>
        /// <returns>An employee object or null</returns>
        Task<Employee?> GetEmployeeById(Guid employeeId);
        /// <summary>
        /// Updates an employee object (employee name and other details)
        /// based on the given employee id
        /// </summary>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the employee with the specified ID does not exist.
        /// </exception>  
        /// <returns>
        /// Updated employee
        /// </returns>
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        /// <summary>
        /// Deletes an employee object based on the employee id 
        /// </summary>
        /// <param name="employeeId">Employee Id (guid) to search</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the employee with the specified ID does not exist.
        /// </exception>
         
        Task DeleteEmployee(Guid employeeId);



    }
}
