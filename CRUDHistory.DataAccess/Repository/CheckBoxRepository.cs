using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository;

public class CheckBoxRepository : Repository<CheckBox>, ICheckBoxRepository{
    private readonly ApplicationDbContext _db;
    public CheckBoxRepository(ApplicationDbContext db) : base(db) => _db = db;


    public void Update(CheckBox checkBox) => _db.Update(checkBox);
}