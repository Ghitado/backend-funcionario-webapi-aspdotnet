using backend_employees_webapi_aspdotnet.DTOs;
using backend_employees_webapi_aspdotnet.Models;

namespace backend_employees_webapi_aspdotnet.Service
{
    public interface IEmployeeService
    {
        Task<Response<List<Employee>>> GetEmployees();
        Task<Response<List<Employee>>> GetByIdEmployee(Guid id);
        Task<Response<Employee>> CreateEmployee(EmployeeDTO employee);
        Task<Response<Employee>> UpdateEmployee(Employee employee);
        Task<Response<Employee>> InactiveEmployee(Guid id);
        Task<Response<Employee>> DeleteEmployee(Guid id);
    }
}
