using Microsoft.EntityFrameworkCore;
using Web_api_1.Domain.Model;

namespace Web_api_1.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BVHAPI7;Database=Database_API_Project;Integrated Security=True;Encrypt=False");
        }
    }
}
