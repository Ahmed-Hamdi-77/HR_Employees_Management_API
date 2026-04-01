using ServicesContracts.DTOs.DepartmentsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DepartmentContracts
{
    public interface IDepartmentUpdaterService
    {
        /// <summary>
        /// Updates the specified Department details based on the given 
        /// Department DepartmentId 
        /// </summary>
        /// <param name="departmentUpdateRequest">Department details to update,
        /// including Department id </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the DepartmentUpdateRequest is empty .
        /// </exception>
        /// <returns>Returns the Department response object after
        /// updation</returns>
        Task<DepartmentResponse> UpdateDepartment(DepartmentUpdateRequest departmentUpdateRequest);
    }
}
