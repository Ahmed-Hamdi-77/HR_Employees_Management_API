using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Department entity
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Adds a department object to the data store
        /// </summary>
        /// <param name="department">Department object to add</param>
        /// <returns>Returns the department object after adding it 
        /// the table</returns>
        Task<Department> AddDepartment(Department department);
        // <summary>
        /// Returns all Departments in the data store
        /// </summary>
        /// <returns>List of departments objects from table</returns>
        Task<List<Department>> GetAllDepartments();
        /// <summary>
        /// Returns a department object based on the given department id
        /// </summary>
        /// <param name="departmentId">DepartmentId (guid) to search</param>
        /// <returns>A department object or null</returns>
        Task<Department?> GetDepartmentById(Guid departmentId);
        /// <summary>
        /// Deletes a department object based on the department id 
        /// </summary>
        /// <param name="departmentId">Department Id (guid) to search</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the department with the specified ID does not exist.
        /// </exception>    
        Task DeleteDepartment(Guid departmentId);

        /// <summary>
        /// Updates an Department object (Department name and other details)        
        /// </summary>
        /// <param name="department">Department object to update</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the Department with the specified ID does not exist.
        /// </exception> 
        /// <returns>
        /// Updated department
        /// </returns>
        Task<Department> UpdateDepartment(Department department);  
    }
}
