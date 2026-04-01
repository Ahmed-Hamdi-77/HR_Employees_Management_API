using ServicesContracts.DTOs.EmployeesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.EmployeeContracts
{
    public interface IEmployeeGetterService
    {
        /// <summary>
        /// Retruns a Employee by Employee id 
        /// </summary>
        /// <returns>Returns a matched Employee with EmployeeId as a EmployeeResponse object</returns>
        
        Task<EmployeeResponse> GetById(Guid id);

        /// <summary>
        /// Returns All Emplyees
        /// </summary>
        /// <returns>Returns a list of objects of EmplyeeResponse type</returns>
        
        Task<List<EmployeeResponse>> GetAllEmployees();
    }
}
