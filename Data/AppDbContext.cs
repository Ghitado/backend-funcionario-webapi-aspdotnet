using Microsoft.EntityFrameworkCore;
using webapi_aspdotnet.Models;
using System.Collections.Generic;

namespace webapi_aspdotnet.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
