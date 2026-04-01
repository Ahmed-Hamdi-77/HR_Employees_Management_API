using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesContracts.DepartmentContracts;
using ServicesContracts.DTOs.DepartmentsDTOs;

namespace HR_Employees_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentAdderService _adder;
        private readonly IDepartmentGetterService _getter;
        private readonly IDepartmentUpdaterService _updater;
        private readonly IDepartmentDeleterService _deleter;

        public DepartmentsController(
            IDepartmentAdderService adder,
            IDepartmentGetterService getter,
            IDepartmentUpdaterService updater,
            IDepartmentDeleterService deleter)
        {
            _adder = adder;
            _getter = getter;
            _updater = updater;
            _deleter = deleter;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentResponse>>> GetAll()
        {
            return Ok(await _getter.GetAll());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResponse>> GetById(Guid id)
        {
            return Ok(await _getter.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentResponse>> Add(DepartmentAddRequest departmentAddRequest)
        {
            var department = await _adder.AddDepartment(departmentAddRequest);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentResponse>> Update(Guid id,DepartmentUpdateRequest departmentUpdateRequest)
        {
            departmentUpdateRequest.Id = id;
            return Ok(await _updater.UpdateDepartment(departmentUpdateRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _deleter.DeleteDepartment(id);
            return NoContent();
        }

    }
}
