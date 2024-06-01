using CRUDHistory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUDHistory.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags{ get; set; }
    public DbSet<ApplicationUser> ApplicationUsers{ get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
    }
    
    /*protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Employee>().HasData(
            new Employee(){ Id = 1, Name = "Hosam", Salary = 200 },
            new Employee(){ Id = 2, Name = "Khaled", Salary = 150 }
        );
    }*/
}