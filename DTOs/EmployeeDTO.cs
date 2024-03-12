using webapi_aspdotnet.Models.Enums;

namespace webapi_aspdotnet.DTOs
{
    public class EmployeeDTO
    {

        public string name { get; private set; }
        public int age { get; private set; }
        public Role role { get; private set; }

        public EmployeeDTO(string name, int age, Role role)
        {
            this.name = name;
            this.age = age;
            this.role = role;
        }
    }
}
