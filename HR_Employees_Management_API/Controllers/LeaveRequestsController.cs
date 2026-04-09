using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesContracts.DTOs.LeavesDTOs;
using ServicesContracts.LeaveContracts;

namespace HR_Employees_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveAdderService _Adder;
        private readonly ILeaveGetterService _Getter;
        private readonly ILeaveUpdaterService _Updater;
        private readonly IHrLeaveApprovalService _HrLeaveApprovalService;
        private readonly IManagerLeaveApprovalService _ManagerLeaveApprovalService;

        public LeaveRequestsController(ILeaveAdderService adder, ILeaveGetterService getter, ILeaveUpdaterService updater, IHrLeaveApprovalService hrLeaveApprovalService, IManagerLeaveApprovalService managerLeaveApprovalService)
        {
            _Adder = adder;
            _Getter = getter;
            _Updater = updater;
            _HrLeaveApprovalService = hrLeaveApprovalService;
            _ManagerLeaveApprovalService = managerLeaveApprovalService;
        }

        [HttpGet("{EmployeeId}")]
        public async Task<ActionResult<List<LeaveResponse>>> GetAll(Guid EmployeeId)
        {
            return Ok(await _Getter.GetAllLeaves(EmployeeId));
        }

        [HttpGet("ByLeaveId/{LeaveId}")]
        public async Task<ActionResult<LeaveResponse>> GetByLeaveId(Guid LeaveId)
        {
            return Ok(await _Getter.GetById(LeaveId));

        }

        [HttpPost]
        public async Task<ActionResult<LeaveResponse>> Add(LeaveAddRequest leaveAddRequest)
        {
            var leave = await _Adder.AddLeave(leaveAddRequest);
            return CreatedAtAction(nameof(GetByLeaveId), new { id = leave.id }, leave);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeaveResponse>> Update(Guid id, LeaveUpdateRequest leaveUpdateRequest)
        {
            leaveUpdateRequest.Id = id;
            return Ok(await _Updater.UpdateLeave(leaveUpdateRequest));
        }

        [HttpPut("{leaveId}/Approve/Manager/{ManagerId}")]
        public async Task<ActionResult<LeaveResponse>> ApproveByManager(Guid leaveId, Guid ManagerId)
        {

            return Ok(await _ManagerLeaveApprovalService.ApproveLeave(leaveId, ManagerId));
        }

        [HttpPut("{leaveId}/Approve/Hr/{HrId}")]
        public async Task<ActionResult<LeaveResponse>> ApproveByHr(Guid leaveId, Guid HrId)
        {
            return Ok(await _HrLeaveApprovalService.ApproveLeave(leaveId, HrId));


        }

        [HttpPut("{leaveId}/Reject/Manager/{ManagerId}")]
        public async Task<ActionResult<LeaveResponse>> RejectByManager(Guid leaveId, Guid ManagerId)
        {
            return Ok(await _ManagerLeaveApprovalService.RejectLeave(leaveId, ManagerId));
        }

        [HttpPut("{leaveId}/Reject/Hr/{HrId}")]
        public async Task<ActionResult<LeaveResponse>> RejectByHr(Guid leaveId, Guid HrId)
        {
            return Ok(await _HrLeaveApprovalService.RejectLeave(leaveId, HrId));
        }
    }
}
