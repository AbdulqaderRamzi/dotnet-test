using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models.Models;

namespace CRUDHistory.DataAccess.Repository;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository{
    private readonly ApplicationDbContext _db;
    
    public EmployeeRepository(ApplicationDbContext db) : base(db) => _db = db;

    public void Update(Employee employee) => _db.Update(employee);
}