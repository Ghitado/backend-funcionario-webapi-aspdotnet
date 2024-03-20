using backend_employees_webapi_aspdotnet.DTOs;
using backend_employees_webapi_aspdotnet.Models;

namespace backend_employees_webapi_aspdotnet.Mapper
{
    public interface IMapper
    {
        Employee NewEmployee(EmployeeDTO employee);
        Employee NewEmployee(Employee employee);
        EmployeeDTO NewEmployeeDTO(Employee employee);
    }
}
