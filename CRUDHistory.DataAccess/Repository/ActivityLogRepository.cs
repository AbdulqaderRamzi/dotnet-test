using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository;

public class ActivityLogRepository: Repository<ActivityLog>, IActivityLogRepository{
    private readonly ApplicationDbContext _db;
    public ActivityLogRepository(ApplicationDbContext db) : base(db){
        _db = db;
    }
    public void Update(ActivityLog activityLog) => _db.ActivityLogs.Update(activityLog);
}