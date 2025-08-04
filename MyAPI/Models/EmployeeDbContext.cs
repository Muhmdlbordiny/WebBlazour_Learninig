using Microsoft.EntityFrameworkCore;
using SharedLibrary.Model;

namespace MyAPI.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> option):base(option)
        {

        }
        
            
        
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
