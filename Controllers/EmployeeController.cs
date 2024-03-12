using Microsoft.AspNetCore.Mvc;
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
        public async Task<IResult> Get()
        {
            var result = await _employeeService.GetEmployees();

            return Results.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id)
        {
            var result = await _employeeService.GetByIdEmployee(id);

            return Results.Ok(result);
        }

        [HttpPost]
        public async Task<IResult> Post(Employee employee)
        {
            var result = await _employeeService.CreateEmployee(employee);

            return Results.Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(Employee employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);

            return Results.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            return Results.Ok(result);
        }
    }
}
