using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using RepositoryContracts;
using ServicesContracts.DTOs.LeavesDTOs;
using ServicesContracts.DTOs.Mappings;
using ServicesContracts.LeaveContracts;
using static Models.Enums.LeaveRequestOptions;

namespace Services.AttendanciesServieces
{
    public class LeaveAdderService : ILeaveAdderService
    {
        private readonly ILeaveRequestRepository _leaveRepository;

        public LeaveAdderService(ILeaveRequestRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        public async Task<LeaveResponse> AddLeave(LeaveAddRequest leaveAddRequest)
        {
           
            //check if the leaveAddRequest is null and throw an exception if it is
            ArgumentNullException.ThrowIfNull(leaveAddRequest);

            // Mapping
            var leave = leaveAddRequest.ToLeave();


            if (leave.FromDate < DateTime.UtcNow.Date)
                throw new ArgumentException("Leave cannot start in the past.");

            if (leave.FromDate > leave.ToDate)
                throw new ArgumentException("Invalid date range.");

            // Get existing leave requests for the same employee from the repository
            var existingLeaves = await _leaveRepository.GetAllLeaveRequestsByEmployeeId(leave.EmployeeId);

            // Check for overlapping leave requests for the same employee
            bool isOverlapping = existingLeaves.Any(l =>
            leave.FromDate <= l.ToDate &&
            leave.ToDate >= l.FromDate &&
            l.Status != LeaveStatus.Rejected
    );

            if (isOverlapping)
                throw new InvalidOperationException("Overlapping leave request.");

            // Generate a new Guid for the leave request
            leave.id = Guid.NewGuid();
            leave.Status = LeaveStatus.Pending;

            // Save the leave request to the data store using the repository
            var addedLeave = await _leaveRepository.AddLeaveRequest(leave);

            return addedLeave.ToLeaveResponse();
        }
    }
}
