using webapi_aspdotnet.Models;

namespace webapi_aspdotnet.Service
{
    public interface IEmployeeService
    {
        Task<IResult> GetEmployees();
        Task<IResult> GetByIdEmployee(Guid id);
        Task<IResult> CreateEmployee(Employee employee);
        Task<IResult> UpdateEmployee(Employee employee);
        Task<IResult> DeleteEmployee(Guid id);
    }
}
