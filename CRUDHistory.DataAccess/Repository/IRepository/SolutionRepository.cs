using CRUDHistory.DataAccess.Data;
using CRUDHistory.Models.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public class SolutionRepository : Repository<Solution>, ISolutionRepository{
    private readonly ApplicationDbContext _db;
    public SolutionRepository(ApplicationDbContext db) : base(db){
        _db = db;
    }
    
    public void Update(Solution solution) => _db.Solutions.Update(solution);
    
}