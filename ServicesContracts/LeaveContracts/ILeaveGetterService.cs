using ServicesContracts.DTOs.LeavesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.LeaveContracts
{
    public interface ILeaveGetterService
    {
        /// <summary>
        /// Returns All Leaves of an Employee by Employee id
        ///  /// <param name="EmployeeId">Employee id that have the attendancies,
        /// </summary>
        /// <returns>Returns a list of objects of LeaveResponse type</returns>
        Task<List<LeaveResponse>> GetAllLeaves(Guid EmployeeId);

        /// <summary>
        /// Retruns a LeaveRequest by Leave id 
        /// </summary>
        /// <returns>Returns a matched LeaveRequest with LeaveId as a LeaveResponse object</returns>
        Task<LeaveResponse?> GetById(Guid id);
    }
}
