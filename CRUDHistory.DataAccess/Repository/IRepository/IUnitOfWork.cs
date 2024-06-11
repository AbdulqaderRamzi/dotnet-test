namespace CRUDHistory.DataAccess.Repository.IRepository;
public interface IUnitOfWork{
    IEmployeeRepository Employee { get; }
    IProductRepository Product { get; }
    ITagRepository Tag{ get; }
    IApplicationUserRepository AppUser{ get; }
    IActivityLogRepository ActivityLog { get; }
    IUserToUserMessagingRepository UserMessage { get; }
    void Save();
}