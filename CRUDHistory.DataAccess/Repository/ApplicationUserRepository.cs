using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository {
    private readonly ApplicationDbContext _db;
    
    public ApplicationUserRepository(ApplicationDbContext db) : base(db){
        _db = db;
    }

    public void Update(ApplicationUser applicationUser) =>_db.Update(applicationUser);
    

}