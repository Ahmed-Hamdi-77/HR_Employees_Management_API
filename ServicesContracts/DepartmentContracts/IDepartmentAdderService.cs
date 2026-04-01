using ServicesContracts.DTOs.DepartmentsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DepartmentContracts
{
    public interface IDepartmentAdderService
    {
        /// <summary>
        /// Add the Department object to the list of the Departments
        /// </summary>
        /// <param name="departmentAddRequest"></param>
        /// <returns>Returns the created department,
        /// along with newly generated DepartmentId</returns>

        Task<DepartmentResponse> AddDepartment(DepartmentAddRequest departmentAddRequest);

    }
}
