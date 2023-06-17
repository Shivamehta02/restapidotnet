using Microsoft.EntityFrameworkCore;
using RestApiCrudDemo.Models;

namespace RestApiCrudDemo.Data
{
	public class EmployeeContext:DbContext
	{
        public EmployeeContext(DbContextOptions options): base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }   
    }
}
