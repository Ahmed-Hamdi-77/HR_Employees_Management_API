using Models.Enums;
using RepositoryContracts;
using ServicesContracts.DTOs.LeavesDTOs;
using ServicesContracts.DTOs.Mappings;
using ServicesContracts.LeaveContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Enums.LeaveRequestOptions;

namespace Services.LeaveRequestsServices
{
    public class HrLeaveAprovalService : IHrLeaveApprovalService
    {
        private readonly ILeaveRequestRepository _leaveRepository;

        public HrLeaveAprovalService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRepository = leaveRequestRepository;
        }

        public async Task<LeaveResponse> ApproveLeave(Guid leaveId, Guid HrId)
        {
            //Check if the provided ID is empty and throw an exception if it is
            if (leaveId == Guid.Empty)
            {
                throw new ArgumentException("Leave ID is invalid.", nameof(leaveId));
            }

            // get the leave request by its ID using the repository
            var leaveRequest = await _leaveRepository.GetLeaveRequestById(leaveId);

            // Throw an exception if the leave request is not approved by the manager first (i.e., if its status is not "Pending")
            if (leaveRequest.Status != LeaveStatus.ApprovedByManager)
                throw new InvalidOperationException("The Manager should approve the requset first!.");

            leaveRequest.Status = LeaveRequestOptions.LeaveStatus.ApprovedByHR;
            leaveRequest.ApprovedByManagerId = HrId;

            // update the leave request in the data store using the repository
            var updatedLeave = await _leaveRepository.UpdateLeaveRequest(leaveRequest);

            return updatedLeave.ToLeaveResponse();
        }

        public async Task<LeaveResponse> RejectLeave(Guid leaveId, Guid HrId)
        {
            //Check if the provided ID is empty and throw an exception if it is
            if (leaveId == Guid.Empty)
            {
                throw new ArgumentException("Leave ID is invalid.", nameof(leaveId));
            }

            // get the leave request by its ID using the repository
            var leaveRequest = await _leaveRepository.GetLeaveRequestById(leaveId);

            // Throw an exception if the leave request is not approved by the manager first (i.e., if its status is not "Pending")
            if (leaveRequest.Status != LeaveStatus.ApprovedByManager)
                throw new InvalidOperationException("The Manager should approve the requset first!.");

            leaveRequest.Status = LeaveRequestOptions.LeaveStatus.Rejected;
            leaveRequest.ApprovedByManagerId = HrId;

            // update the leave request in the data store using the repository
            var updatedLeave = await _leaveRepository.UpdateLeaveRequest(leaveRequest);

            return updatedLeave.ToLeaveResponse();
        }
    }
}
