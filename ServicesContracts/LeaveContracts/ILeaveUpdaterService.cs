using ServicesContracts.DTOs.LeavesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.LeaveContracts
{
    public interface ILeaveUpdaterService
    {
        /// <summary>
        /// Updates the specified LeaveRequest details based on the given 
        /// Leave LeaveId 
        /// </summary>
        /// <param name="leaveUpdateRequest">Leave details to update,
        /// including Leave id </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the LeaveUpdateRequest is empty .
        /// </exception>
        /// <returns>Returns the Leave response object after
        /// updation</returns>
        Task<LeaveResponse> UpdateLeave(LeaveUpdateRequest leaveUpdateRequest);
    }
}
