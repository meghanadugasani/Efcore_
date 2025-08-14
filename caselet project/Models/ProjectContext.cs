using Apidbfirstassign.Models;
//using EmployeeProjectTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectTrackerAPI.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { EmployeeId = 1, Name = "Meghana", Email = "maggi@gmail.com", Salary = 50000, ProjectId = 1 },
                    new Employee { EmployeeId = 2, Name = "Sumanthi", Email = "sumathi@gmail.com", Salary = 60000, ProjectId = 1 }
                );

            modelBuilder.Entity<Project>()
                .HasData(
                    new Project { ProjectId = 1, ProjectName = "Project A", Budget = 2000000 },
                    new Project { ProjectId = 2, ProjectName = "Project B", Budget = 15467890 }
                );
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    }

