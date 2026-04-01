using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DepartmentContracts
{
    public interface IDepartmentDeleterService
    {
        /// <summary>
        /// Deletes the Department with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier </param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the Department with the specified ID does not exist.
        /// </exception>   

        Task DeleteDepartment(Guid id);
    }
}
