using ServicesContracts.DTOs.LeavesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.LeaveContracts
{
    public interface IManagerLeaveApprovalService
    {
        /// <summary>
        /// Approves the leave request with the specified identifier by the manager first.
        /// </summary>
        /// <param name="leaveId">The unique identifier of the leave request to approve.</param>
        /// <param name="ManagerId">The unique identifier of the Manager id that'll approve the request.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the leave request with the specified ID does not exist.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the leave request cannot be approved 
        /// (e.g., it is already approved or rejected).
        /// </exception>
        /// <returns>
        /// Returns the updated leave request details after approval.
        /// </returns>
        Task<LeaveResponse> ApproveLeave(Guid leaveId, Guid ManagerId);

        /// <summary>
        /// Rejects the leave request with the specified identifier by the manager.
        /// </summary>
        /// <param name="leaveId">The unique identifier of the leave request to reject.</param>
        /// <param name="ManagerId">The unique identifier of the Manager id that'll reject the request.</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the leave request with the specified ID does not exist.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the leave request cannot be rejected 
        /// (e.g., it is already approved or rejected).
        /// </exception>
        /// <returns>
        /// Returns the updated leave request details after rejection.
        /// </returns>
        Task<LeaveResponse> RejectLeave(Guid leaveId,Guid ManagerId);
    }
}
