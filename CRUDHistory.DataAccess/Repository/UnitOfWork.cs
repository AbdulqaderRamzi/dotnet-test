using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;

namespace CRUDHistory.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork{
    private readonly ApplicationDbContext _db;
    public IEmployeeRepository Employee { get; }
    public ISolutionRepository Solution{ get; }

    public UnitOfWork(ApplicationDbContext db){
        _db = db;
        Employee = new EmployeeRepository(_db);
        Solution= new SolutionRepository(_db);
    }

    public void Save() => _db.SaveChanges();
}