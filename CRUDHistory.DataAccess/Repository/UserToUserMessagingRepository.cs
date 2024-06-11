using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository;

public class UserToUserMessagingRepository : Repository<Message>, IUserToUserMessagingRepository{
    private readonly ApplicationDbContext _db;
    public UserToUserMessagingRepository(ApplicationDbContext db) : base(db){
        _db = db;
    }
    public void Update(Message message) => _db.Update(message);
    
}