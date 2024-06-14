using System.Security.Claims;
using System.Text;
using CRUDHistory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace CRUDHistory.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags{ get; set; }
    public DbSet<ApplicationUser> ApplicationUsers{ get; set; }
    public DbSet<ActivityLog> ActivityLogs{ get; set; }
    public DbSet<Message> Messages{ get; set; }
    public DbSet<CheckBox> CheckBoxes{ get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) 
        : base(options){
        _httpContextAccessor = httpContextAccessor;
    }
    
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<>().HasData(
            new Employee(){ Id = 1, Name = "Hosam", Salary = 200 },
            new Employee(){ Id = 2, Name = "Khaled", Salary = 150 }
        );
    }
    */

    public override int SaveChanges(){
        var modifiedEntries = ChangeTracker
            .Entries()
            .Where(x => x.State is
             EntityState.Added or EntityState.Modified 
             or EntityState.Deleted)
            .ToList();
        var claimsIdentity = (ClaimsIdentity) _httpContextAccessor.HttpContext.User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        foreach (var entity in modifiedEntries){
            /*if (entity.Entity.GetType().ToString().Equals("CheckBox")) {
                continue;
            }*/
            var updates = GetUpdate(entity);
            if (updates.Count == 0) 
                updates.Add(["", "", ""]);
            foreach (var update in updates){
                var auditLog = new ActivityLog{
                    Action = entity.State.ToString(),
                    TimeStamp = DateTime.Now,
                    EntityType = entity.Entity.GetType().ToString(),
                    ApplicationUserId = userId,
                    Property = updates.Count != 0 ? update[0] : "",
                    OldValue = updates.Count != 0 ? update[1] : "",
                    NewValue = updates.Count != 0 ? update[2] : ""
                    /*Changes = GetUpdate(entity)*/
                };
                ActivityLogs.Add(auditLog);
            }
        }
        return base.SaveChanges();
    }

    private static List<List<string?>> GetUpdate(EntityEntry entry){
        /*var str = new StringBuilder();*/
        List<List<string?>> list = [];
        foreach (var prop in entry.OriginalValues.Properties){
            var originalValue = entry.OriginalValues[prop];
            var currentValue = entry.CurrentValues[prop];
            if (currentValue is null || originalValue is null) continue;
            if (!Equals(originalValue, currentValue)){
                list.Add([prop.Name, originalValue.ToString(), currentValue.ToString()]);
                //str.AppendLine($"{prop.Name}: From -> {originalValue} To -> {currentValue}.");
            }   
        }
        return list;
    }
}