using webapi_aspdotnet.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_aspdotnet.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Role Role { get; private set; }
        public bool Active { get; private set; } = true;
        public DateTime CreationDate { get; private set; } = DateTime.Now;
        public DateTime UpdateDate { get; private set; } = DateTime.Now;

        public Employee(string name, int age, Role role)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Age = age;
            this.Role = role;
            this.Active = true;
        }

        public void NewModification()
        {
            UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void InactivateEmployee()
        {
            Active = false;
        }
    }
}
