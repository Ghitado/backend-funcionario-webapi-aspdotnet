using webapi_aspdotnet.DTOs;
using webapi_aspdotnet.Models;

namespace webapi_aspdotnet.Service
{
    public interface IEmployeeService
    {
        Task<Response<List<Employee>>> GetEmployees();
        Task<Response<List<Employee>>> GetByIdEmployee(Guid id);
        Task<Response<EmployeeDTO>> CreateEmployee(Employee employee);
        Task<Response<EmployeeDTO>> UpdateEmployee(Employee employee);
        Task<Response<EmployeeDTO>> DeleteEmployee(Guid id);
    }
}
