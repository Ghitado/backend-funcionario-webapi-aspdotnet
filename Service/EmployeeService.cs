using Microsoft.EntityFrameworkCore;
using backend_employees_webapi_aspdotnet.Data;
using backend_employees_webapi_aspdotnet.DTOs;
using backend_employees_webapi_aspdotnet.Mapper;
using backend_employees_webapi_aspdotnet.Models;

namespace backend_employees_webapi_aspdotnet.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<List<Employee>>> GetEmployees()
        {
            Response<List<Employee>> response = new Response<List<Employee>>();

            var employees = await _context.Employees
                .Where(emp => emp.Active)
                .ToListAsync();

            if (employees == null)
            {
                response.Message = "No employees found!";
                return response;
            }

            response.Data = new List<Employee>(employees);
            response.Message = "Employees found successfully!";

            return response;
        }

        public async Task<Response<List<Employee>>> GetByIdEmployee(Guid id)
        {
            Response<List<Employee>> response = new Response<List<Employee>>();

            var employee = await _context.Employees
                .Where(emp => emp.Active && emp.Id == id)
                .ToListAsync();

            if (employee == null)
            {
                response.Message = "Employee not found!";
                return response;
            }

            response.Data = employee;
            response.Message = "Employee found successfully";

            return response;
        }

        public async Task<Response<Employee>> CreateEmployee(EmployeeDTO employee)
        {
            Response<Employee> response = new Response<Employee>();

            var newEmployee = _mapper.NewEmployee(employee);

            await _context.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            response.Data = newEmployee; 
            response.Message = "Employee successfully created!";

            return response;
        }

        public async Task<Response<Employee>> UpdateEmployee(Employee employee)
        {
            Response<Employee> response = new Response<Employee>();

            var employeeExists = await _context.Employees
                .AsNoTracking()
                .SingleOrDefaultAsync(emp => emp.Active && emp.Id == employee.Id);

            if (employeeExists == null)
            {
                response.Message = "Employee not found!";
                return response;
            }

            employee.NewModification();

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            response.Data = employee;
            response.Message = "Employee update successfully!";

            return response;
        }

        public async Task<Response<Employee>> InactiveEmployee(Guid id)
        {
            Response<Employee> response = new Response<Employee>();

            var employee = await _context.Employees
                .SingleOrDefaultAsync(emp => emp.Active && emp.Id == id);

            if (employee == null)
            {
                response.Message = "Employee not found!";
                return response;
            }

            employee.InactivateEmployee();
            await _context.SaveChangesAsync();

            response.Data = _mapper.NewEmployee(employee);
            response.Message = "Employee successfully deactivated!";

            return response;
        }

        public async Task<Response<Employee>> DeleteEmployee(Guid id)
        {
            Response<Employee> response = new Response<Employee>();

            var employee = await _context.Employees
                .SingleOrDefaultAsync(emp => emp.Active && emp.Id == id);

            if (employee == null)
            {
                response.Message = "Employee not found!";
                return response;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            response.Data = _mapper.NewEmployee(employee);
            response.Message = "Employee successfully deleted!";

            return response;
        }
    }
}
