using Microsoft.EntityFrameworkCore;
using backend_funcionario_webapi_aspdotnet.Models;

namespace backend_funcionario_webapi_aspdotnet.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
