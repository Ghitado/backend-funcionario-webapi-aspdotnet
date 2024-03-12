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

        public async Task<Response<List<EmployeeDTO>>> GetEmployees()
        {
            Response<List<EmployeeDTO>> response = new Response<List<EmployeeDTO>>();

            var employees = await _context.Employees
                .Where(emp => emp.Active)
                .Select(emp => new EmployeeDTO(emp.Name, emp.Age, emp.Role))
                .ToListAsync();

            if (employees == null)
            {
                response.Message = "No employees found!";
                return response;
            }

            response.Data = new List<EmployeeDTO>(employees);
            response.Message = "Employees found successfully!";

            return response;
        }

        public async Task<Response<List<EmployeeDTO>>> GetByIdEmployee(Guid id)
        {
            Response<List<EmployeeDTO>> response = new Response<List<EmployeeDTO>>();

            var employee = await _context.Employees
                .Where(emp => emp.Active && emp.Id == id)
                .Select(emp => new EmployeeDTO(emp.Name, emp.Age, emp.Role))
                .ToListAsync();

            if (employee == null)
            {
                response.Message = "Employee not found!";
                return response;
            }

            response.Data = new List<EmployeeDTO>(employee);
            response.Message = "Employee found successfully";

            return response;
        }

        public async Task<Response<EmployeeDTO>> CreateEmployee(Employee employee)
        {
            Response<EmployeeDTO> response = new Response<EmployeeDTO>();
            
            var employeeExists = await _context.Employees
                .AnyAsync(emp => emp.Id == employee.Id);

            if (employeeExists)
            {
                response.Message = "Employee already exists!";
                return response;
            }

            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();

            response.Data = new EmployeeDTO(employee.Name, employee.Age, employee.Role);
            response.Message = "Employee successfully created!";

            return response;
        }

        public async Task<Response<EmployeeDTO>> UpdateEmployee(Employee employee)
        {
            Response<EmployeeDTO> response = new Response<EmployeeDTO>();

            var updateEmployee = await _context.Employees
                .SingleOrDefaultAsync(emp => emp.Active && emp.Id == employee.Id);

            if (employee == null)
            {
                response.Message = "Employee not found!";
                return response;
            }

            updateEmployee.NewModification();

            await _context.AddAsync(updateEmployee);
            await _context.SaveChangesAsync();

            response.Data = new EmployeeDTO(employee.Name, employee.Age, employee.Role);
            response.Message = "Employee update successfully!";

            return response;
        }

        public async Task<Response<EmployeeDTO>> DeleteEmployee(Guid id)
        {
            Response<EmployeeDTO> response = new Response<EmployeeDTO>();

            var employee = await _context.Employees
                .SingleOrDefaultAsync(emp => emp.Active && emp.Id == id);

            if (employee == null)
            {
                response.Message = "Employee not found!";
                return response;
            }

            employee.InactivateEmployee();
            await _context.SaveChangesAsync();

            response.Data = new EmployeeDTO(employee.Name, employee.Age, employee.Role);
            response.Message = "Employee successfully deactivated!";

            return response;
        }
    }
}
