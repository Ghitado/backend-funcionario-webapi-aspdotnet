using Microsoft.EntityFrameworkCore;
using webapi_aspdotnet.Data;
using webapi_aspdotnet.DTOs;
using webapi_aspdotnet.Models;

namespace webapi_aspdotnet.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> GetEmployees()
        {
            var employees = await _context.Employees
                .Where(emp => emp.Active)
                .Select(emp => new EmployeeDTO(emp.Name, emp.Age, emp.Role))
                .ToListAsync();

            return Results.Ok(employees);
        }

        public async Task<IResult> GetByIdEmployee(Guid id)
        {
            var employee = await _context.Employees
                .Where(emp => emp.Active && emp.Id == id)
                .Select(emp => new EmployeeDTO(emp.Name, emp.Age, emp.Role))
                .ToListAsync();

            if (employee == null)
                return Results.NotFound("Employee not found!");

            return Results.Ok(employee);
        }

        public async Task<IResult> CreateEmployee(Employee employee)
        {
            var employeeExists = await _context.Employees
                .AnyAsync(emp => emp.Id == employee.Id);

            if (employeeExists)
                return Results.Conflict("Employee already exists!");

            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();

            var newEmployee = new EmployeeDTO(employee.Name, employee.Age, employee.Role);

            return Results.Ok(newEmployee);
        }

        public async Task<IResult> UpdateEmployee(Employee employee)
        {
            var updateEmployee = await _context.Employees
                .SingleOrDefaultAsync(emp => emp.Active && emp.Id == employee.Id);

            if (updateEmployee == null)
                return Results.NotFound("Employee not found!");

            updateEmployee.NewModification();

            await _context.AddAsync(updateEmployee);
            await _context.SaveChangesAsync();

            var newEmployee = new EmployeeDTO(employee.Name, employee.Age, employee.Role);

            return Results.Ok(newEmployee);
        }

        public async Task<IResult> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees
                .SingleOrDefaultAsync(emp => emp.Active && emp.Id == id);

            if (employee == null)
                return Results.NotFound("Employee not found!");

            employee.InactivateEmployee();
            await _context.SaveChangesAsync();

            return Results.Ok("Employee successfully deactivated!");
        }
    }
}
