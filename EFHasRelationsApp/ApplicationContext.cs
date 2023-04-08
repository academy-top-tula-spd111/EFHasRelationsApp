using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFHasRelationsApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        //public DbSet<EmployeeInfo> EmployeeInfos => Set<EmployeeInfo>();
        //public DbSet<Company> Companies => Set<Company>();
        public DbSet<Project> Projects => Set<Project>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ISC66B9\\MSSQLSERVER2022;Initial Catalog=RelationsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // simple freign key - two tables
            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.Info)
            //            .WithOne(i => i.Employee)
            //            .HasForeignKey<EmployeeInfo>(i => i.EmployeeId);

            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.Info)
            //            .WithOne(i => i.Employee)
            //            .HasForeignKey<EmployeeInfo>(i => i.Id);
            //modelBuilder.Entity<Employee>().ToTable("EmployeesFull");
            //modelBuilder.Entity<EmployeeInfo>().ToTable("EmployeesFull");

            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.Company)
            //            .WithMany(c => c.Employees)
            //            .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Projects)
                        .WithMany(p => p.Employees)
                        .UsingEntity(rt => rt.ToTable("EmplProj"));

        }
    }
}
