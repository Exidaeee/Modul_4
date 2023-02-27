using HW_4._3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4._3
{
    public class DatabaseContext :DbContext
    {      
       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HW_4.3;Trusted_Connection=True;MultipleActiveResultSets=true")
                   .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(r => r.Office)
                .WithMany(r => r.Employees)
                .HasForeignKey(k => k.OfficeId);
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(r => r.Employee)
                .WithMany(r => r.EmployeeProjects)
                .HasForeignKey(k => k.EmployeeId);
            modelBuilder.Entity<EmployeeProject>()
               .HasOne(r => r.Project)
               .WithMany(r => r.EmployeeProjects)
               .HasForeignKey(k => k.ProjectId);
            modelBuilder.Entity<Employee>()
               .HasOne(r => r.Title)
               .WithMany(r => r.Employees)
               .HasForeignKey(k => k.TitleId);
            modelBuilder.Entity<Project>()
                .HasOne(r => r.Client)
                .WithMany(r => r.Projects)
                .HasForeignKey(k => k.ClientId);
                
        }
    }
}
