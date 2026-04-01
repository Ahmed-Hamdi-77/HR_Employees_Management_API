using Models;
using Models.Enums;
using ServicesContracts.DTOs.LeavesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTOs.Mappings
{
    public static class LeavesMappingExtensions
    {
        // An extension method to convert an object of LeaveRequest entity to LeaveResponse object
        public static LeaveResponse ToLeaveResponse(this LeaveRequest leave)
        {
            //LeaveRequest=>LeaveResponse
            return new LeaveResponse
            {
                id = leave.id,
                FromDate = leave.FromDate,
                ToDate = leave.ToDate,
                Type = leave.Type,
                Status = leave.Status,
                EmployeeId = leave.EmployeeId
            };
        }

        // An extension method to convert LeaveUpdateRequest object to LeaveRequest entity
        public static LeaveRequest ToLeave(this LeaveUpdateRequest leaveUpdateRequest)
        {
            //LeaveUpdateRequest=>LeaveRequest
            return new LeaveRequest
            {
                FromDate = leaveUpdateRequest.FromDate,
                ToDate = leaveUpdateRequest.ToDate,
                Type = Enum.Parse<LeaveRequestOptions.LeaveType>(leaveUpdateRequest.Type!),
                Status = Enum.Parse<LeaveRequestOptions.LeaveStatus>(leaveUpdateRequest.Status!),
            };
        }

        // An extension method to convert LeaveAddRequest object to LeaveRequest entity
        public static LeaveRequest ToLeave(this LeaveAddRequest leaveAddRequest)
        {
            //LeaveAddRequest=>LeaveRequest
            return new LeaveRequest
            {
                FromDate = leaveAddRequest.FromDate,
                ToDate = leaveAddRequest.ToDate,
                Type = Enum.Parse<LeaveRequestOptions.LeaveType>(leaveAddRequest.Type!),
                Status = Enum.Parse<LeaveRequestOptions.LeaveStatus>(leaveAddRequest.Status!),
                EmployeeId = leaveAddRequest.EmployeeId,
                ApprovedByManagerId = leaveAddRequest.ApprovedByManagerId,
                ApprovedByHRId = leaveAddRequest.ApprovedByHRId
            };
        }
    }
}
