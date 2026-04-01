using RepositoryContracts;
using ServicesContracts.DTOs.LeavesDTOs;
using ServicesContracts.DTOs.Mappings;
using ServicesContracts.LeaveContracts;
using static Models.Enums.LeaveRequestOptions;

namespace Services.AttendanciesServieces
{
    public class LeaveUpdaterService : ILeaveUpdaterService
    {
        private readonly ILeaveRequestRepository _leaveRepository;

        public LeaveUpdaterService(ILeaveRequestRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }
        public async Task<LeaveResponse> UpdateLeave(LeaveUpdateRequest leaveUpdateRequest)
        {
            // mapping
            var leave = leaveUpdateRequest.ToLeave();

            // Cann't Update the leave if it is already processed (i.e., if its status is not "Pending")
            if (leave.Status != LeaveStatus.Pending)
                throw new InvalidOperationException("Cannot update processed leave.");

            // Update the leave request in the data store using the repository
            var updatedLeave = await _leaveRepository.UpdateLeaveRequest(leave);

            return updatedLeave.ToLeaveResponse();
        }
    }
}
