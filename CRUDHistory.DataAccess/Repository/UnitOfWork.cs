using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;

namespace CRUDHistory.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork{
    private readonly ApplicationDbContext _db;
    public IEmployeeRepository Employee { get; }
    public IProductRepository Product{ get; }
    public ITagRepository Tag{ get; }
    public IApplicationUserRepository AppUser { get; }
    public IActivityLogRepository ActivityLog{ get; }
    public IUserToUserMessagingRepository UserMessage{ get; }
    public ICheckBoxRepository CheckBox{ get; }
    public UnitOfWork(ApplicationDbContext db){
        _db = db;
        Employee = new EmployeeRepository(_db);
        Product= new ProductRepository(_db);
        Tag = new TagRepository(_db);
        AppUser = new ApplicationUserRepository(_db);
        ActivityLog = new ActivityLogRepository(_db);
        UserMessage = new UserToUserMessagingRepository(_db);
        CheckBox = new CheckBoxRepository(_db);
    }
    
    public void Save() => _db.SaveChanges();
}