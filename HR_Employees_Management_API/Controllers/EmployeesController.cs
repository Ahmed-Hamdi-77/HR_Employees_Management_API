using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesContracts.DTOs.EmployeesDTOs;
using ServicesContracts.EmployeeContracts;

namespace HR_Employees_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeAdderService _Adder;
        private readonly IEmployeeGetterService _Getter;
        private readonly IEmployeeUpdaterService _Updater;
        private readonly IEmployeeDeleterService _Deleter;

        public EmployeesController(IEmployeeAdderService adder, IEmployeeGetterService getter, IEmployeeUpdaterService updater, IEmployeeDeleterService deleter)
        {
            _Adder = adder;
            _Getter = getter;
            _Updater = updater;
            _Deleter = deleter;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponse>>> GetAll()
        {
            return Ok(await _Getter.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> GetById(Guid id)
        {
            return Ok(await _Getter.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> Add(EmployeeAddRequest employeeAddRequest)
        {
            var employee = await _Adder.AddEmployee(employeeAddRequest);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeResponse>> Update(Guid id ,EmployeeUpdateRequest employeeUpdateRequest)
        {
            employeeUpdateRequest.Id = id;
            return Ok(await _Updater.UpdateEmployee(employeeUpdateRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _Deleter.DeleteEmployee(id);
            return NoContent();
        }
    }
}
