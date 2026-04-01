using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.EmployeeContracts
{
    public interface IEmployeeDeleterService
    {
        /// <summary>
        /// Deletes the Employee with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Employee</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the Employee with the specified ID does not exist.
        /// </exception>   
        Task DeleteEmployee(Guid id);
    }

}
