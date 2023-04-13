using Microsoft.EntityFrameworkCore;

namespace WebAPIRepositoryPattern.Models
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        public DbSet<Employee> EmployeeInfos { get; set; }
    }
}
