using backend_employees_webapi_aspdotnet.Models.Enums;

namespace backend_employees_webapi_aspdotnet.DTOs
{
    public class EmployeeDTO
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Role Role { get; private set; }
        public bool Active { get; private set; }

        public EmployeeDTO(string name, int age, Role role)
        {
            Name = name;
            Age = age;
            Role = role;
            Active = true;
        }
    }
}
