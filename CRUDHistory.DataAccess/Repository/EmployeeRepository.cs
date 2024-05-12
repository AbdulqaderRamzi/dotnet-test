using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository{
    private readonly ApplicationDbContext _db;
    
    public EmployeeRepository(ApplicationDbContext db) : base(db) => _db = db;

    public void Update(Employee employee){
        var employeeFromDb = _db.Employees.FirstOrDefault(u => u.Id == employee.Id);
        if (employeeFromDb is null) return;
        employeeFromDb.Email = employee.Email;
        employeeFromDb.Name = employee.Name;
        employeeFromDb.Tag = employee.Tag;
        employeeFromDb.Career = employee.Career;
        employeeFromDb.Salary = employee.Salary;
        employeeFromDb.DateTime = employee.DateTime;
        employeeFromDb.TagId = employee.TagId;
        if (!string.IsNullOrEmpty(employee.imageUrl))
            employeeFromDb.imageUrl = employee.imageUrl;
    }
}