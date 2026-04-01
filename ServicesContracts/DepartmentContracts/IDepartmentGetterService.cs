using ServicesContracts.DTOs.DepartmentsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DepartmentContracts
{
    public interface IDepartmentGetterService
    {
        /// <summary>
        /// Retruns a Department by Department id 
        /// </summary>
        /// <returns>Returns a matched Department with DepartmentId as a DepartmentResponse object</returns>
        Task<DepartmentResponse?> GetById(Guid id);

        /// <summary>
        /// Returns a list of all Departments in the system as a list of DepartmentResponse objects.    
        /// </summary>
        /// <returns>Returns all departments in the data source</returns>
        Task<List<DepartmentResponse?>> GetAll();
    }
}
