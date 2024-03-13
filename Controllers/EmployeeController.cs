using Microsoft.AspNetCore.Mvc;
using webapi_aspdotnet.DTOs;
using webapi_aspdotnet.Models;
using webapi_aspdotnet.Service;

namespace webapi_aspdotnet.Controllers
{
    [ApiController]
    [Route("employee")]
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
        public async Task<ActionResult<List<Employee>>> Get(Guid id)
        {
            var result = await _employeeService.GetByIdEmployee(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Employee employee)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            return Ok(result);
        }
    }
}
