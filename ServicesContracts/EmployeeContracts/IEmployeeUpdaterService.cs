using ServicesContracts.DTOs.EmployeesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.EmployeeContracts
{
    public interface IEmployeeUpdaterService
    {
        /// <summary>
        /// Updates the Employee with the specified identifier using the provided Employee data.
        /// </summary>       
        /// <param name="employeeUpdateRequest">An object containing the updated Employee data.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the EmployeeUpdateRequest is empty .
        /// </exception>
        /// <returns>Returns the Employee response object after
        /// updation</returns>
        Task<EmployeeResponse> UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest);
    }
}
