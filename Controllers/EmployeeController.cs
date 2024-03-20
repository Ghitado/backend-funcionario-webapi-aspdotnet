using Microsoft.AspNetCore.Mvc;
using backend_employees_webapi_aspdotnet.DTOs;
using backend_employees_webapi_aspdotnet.Models;
using backend_employees_webapi_aspdotnet.Service;

namespace backend_employees_webapi_aspdotnet.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var result = await _employeeService.GetEmployees();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmployeeDTO>>> Get(Guid id)
        {
            var result = await _employeeService.GetByIdEmployee(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmployeeDTO employee)
        {
            var result = await _employeeService.CreateEmployee(employee);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Employee employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);

            return Ok(result);
        }

        [HttpPut("inactiveEmployee")]
        public async Task<ActionResult> Inactive(Guid id)
        {
            var result = await _employeeService.InactiveEmployee(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            return Ok(result);
        }
    }
}
