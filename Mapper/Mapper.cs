using backend_employees_webapi_aspdotnet.DTOs;
using backend_employees_webapi_aspdotnet.Models;

namespace backend_employees_webapi_aspdotnet.Mapper
{
    public class Mapper : IMapper
    {
        public Employee NewEmployee(EmployeeDTO employee)
        {
            return new Employee(employee.Name, employee.Age, employee.Role);
        }

        public Employee NewEmployee(Employee employee)
        {
            return new Employee(employee.Name, employee.Age, employee.Role);
        }

        public EmployeeDTO NewEmployeeDTO(Employee employee)
        {
            return new EmployeeDTO(employee.Name, employee.Age, employee.Role);
        }
    }
}
