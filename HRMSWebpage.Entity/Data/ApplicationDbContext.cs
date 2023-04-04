using HRMSWebpage.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }
        public DbSet<Department> Dept { get; set; }
        public DbSet<Position> Post { get; set; }
        public DbSet<Salary> Sal { get; set; }
        public DbSet<ProjectApplication> PrjtApp { get; set; }
        public DbSet<Project> Prjt { get; set; }
        public DbSet<Attendence> Attn { get; set; }
        public DbSet<LeaveApplication> LeaveApp { get; set; }
        public DbSet<Leaves> Leave { get; set; }
        public DbSet<TrainingApplication> TrainingApp { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Employee> Emp { get; set; }

    }
}
