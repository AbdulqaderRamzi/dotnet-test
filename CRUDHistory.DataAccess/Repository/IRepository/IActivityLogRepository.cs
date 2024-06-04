using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface IActivityLogRepository : IRepository<ActivityLog>{
    void Update(ActivityLog activityLog);
}