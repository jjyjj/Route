using Microsoft.EntityFrameworkCore;
using Route.Api.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Route.Api.Data
{
    public class RouteDbContext : DbContext
    {
        public RouteDbContext(DbContextOptions<RouteDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //对实体字段进行限制条件：非空，最大长度，以及2个表的关系
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Company>()
                .Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Company>()
                .Property(x => x.Introuduction)
                .HasMaxLength(500);

            modelBuilder.Entity<Employee>()
               .Property(x => x.EmployeeNo)
               .HasMaxLength(100);
            modelBuilder.Entity<Employee>()
               .Property(x => x.FirstName)
               .HasMaxLength(50);
            modelBuilder.Entity<Employee>()
               .Property(x => x.LastName)
               .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasForeignKey(x=>x.CompanyId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>().HasData(
                new Company {
                Id=Guid.Parse("70cfeac7-7b2c-4420-895f-23f5bfe59eb3"),
                Name="Microsoft",
                Introuduction="Great company"
                },
                 new Company {
                     Id = Guid.Parse("84261e41-2a84-4a53-aa37-3e174324782d"),
                     Name = "Google",
                     Introuduction = "Don not be evil"
                 },
                  new Company {
                      Id = Guid.Parse("b93657cd-0c9c-434a-af01-9552eb5c1686"),
                      Name = "jjy",
                      Introuduction = "asd company"
                  }
                );


        }
    }
}
