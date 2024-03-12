using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models.Models;

namespace CRUDHistory.DataAccess.Repository;

public class SolutionRepository : Repository<Solution>, ISolutionRepository{
    private readonly ApplicationDbContext _db;
    public SolutionRepository(ApplicationDbContext db) : base(db){
        _db = db;
    }

    public void Update(Solution solution) => _db.Update(solution);
}