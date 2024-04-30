using CRUDHistory.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDHistory.DataAccess.Data;

public class ApplicationDbContext : DbContext{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags{ get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
    }
    
    /*protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Employee>().HasData(
            new Employee(){ Id = 1, Name = "Hosam", Salary = 200 },
            new Employee(){ Id = 2, Name = "Khaled", Salary = 150 }
        );
    }*/
}