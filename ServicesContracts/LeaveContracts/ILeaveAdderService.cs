using ServicesContracts.DTOs.LeavesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.LeaveContracts
{
    public interface ILeaveAdderService
    {
        /// <summary>
        /// Add the LeaveRequest object to the list of the Leaves
        /// </summary>
        /// <param name="leaveAddRequest"></param>
        /// <returns>
        /// Returns the created leave details including the generated LeaveId.
        /// </returns>

        Task<LeaveResponse> AddLeave(LeaveAddRequest leaveAddRequest);

    }
}
