using Microsoft.EntityFrameworkCore;
using backend_employees_webapi_aspdotnet.Models;
using System.Collections.Generic;

namespace backend_employees_webapi_aspdotnet.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
