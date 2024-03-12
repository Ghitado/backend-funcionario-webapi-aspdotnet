using Microsoft.EntityFrameworkCore;
using webapi_aspdotnet.Models;
using System.Collections.Generic;

namespace webapi_aspdotnet.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-N3HGSBN\\TITE; database=cobaia; trusted_connection=true;TrustServerCertificate=true;");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
