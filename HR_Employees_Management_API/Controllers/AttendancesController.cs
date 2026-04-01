using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesContracts.AttendanceContracts;
using ServicesContracts.DTOs.AttendancesDTOs;

namespace HR_Employees_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceAdderService _Adder;
        private readonly IAttendanceGetterService _Getter;
        private readonly IAttendanceUpdaterService _Updater;
        private readonly IAttendanceDeleterService _Deleter;

        public AttendancesController(IAttendanceAdderService adder, IAttendanceGetterService getter, IAttendanceUpdaterService updater, IAttendanceDeleterService deleter)
        {
            _Adder = adder;
            _Getter = getter;
            _Updater = updater;
            _Deleter = deleter;
        }

        [HttpGet("AllByEmployee/{employeeId}")]
        public async Task<ActionResult<List<AttendanceResponse>>> GetAllByEmployee(Guid EmployeeId)
        {

            return Ok(await _Getter.GetAllAttendances(EmployeeId));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AttendanceResponse>> GetById(Guid Id)
        {
            return Ok(await _Getter.GetById(Id));
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceResponse>> Add(AttendanceAddRequest attendanceAddRequest)
        {
            var attendance = await _Adder.AddAttendance(attendanceAddRequest);
            return CreatedAtAction(nameof(GetById), new { id = attendance.Id }, attendance);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AttendanceResponse>> Update(Guid id , AttendanceUpdateRequest attendanceUpdateRequest)
        {
            attendanceUpdateRequest.Id = id;
            return Ok(await _Updater.UpdateAttendance(attendanceUpdateRequest));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await _Deleter.DeleteAttendance(Id);
            return NoContent();
        }

    }
}
