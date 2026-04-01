using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing LeaveRequest entity
    /// </summary>
    public interface ILeaveRequestRepository
    {
        /// <summary>
        /// Adds a LeaveRequest object to the data store
        /// </summary>
        /// <param name="leaveRequest">LeaveRequest object to add</param>
        /// <returns>Returns the LeaveRequest object after adding it 
        /// the table</returns>
        Task<LeaveRequest> AddLeaveRequest(LeaveRequest leaveRequest);
        /// <summary>
        /// Returns all LeaveRequest in the data store based on the employeeId
        /// </summary>
        /// <returns>List of LeaveRequest objects from table</returns>
        Task<List<LeaveRequest>> GetAllLeaveRequestsByEmployeeId(Guid employeeId);
        /// <summary>
        /// Returns a LeaveRequest object based on the given LeaveRequest id
        /// </summary>
        /// <param name="leaveRequestId">LeaveRequestId (guid) to search</param>
        /// <returns>A LeaveRequest object or null</returns>
        Task<LeaveRequest?> GetLeaveRequestById(Guid leaveRequestId);
        /// <summary>
        /// Updates a LeaveRequest object 
        /// </summary>
        /// <param name="leaveRequest">LeaveRequest object to update</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the LeaveRequest with the specified ID does not exist.
        /// </exception> 
        /// <returns>
        /// Updated leave request
        /// </returns>
        Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequest);
        /// <summary>
        /// Deletes a LeaveRequest object based on the LeaveRequest id 
        /// </summary>
        /// <param name="leaveRequestId">LeaveRequest Id (guid) to search</param>
        /// <exception cref="KeyNotFoundException">
        /// Thrown when the LeaveRequest with the specified ID does not exist.
        /// </exception> 
        
        Task DeleteLeaveRequest(Guid leaveRequestId);
    }
}
