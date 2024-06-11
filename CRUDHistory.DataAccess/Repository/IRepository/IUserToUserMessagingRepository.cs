using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface IUserToUserMessagingRepository : IRepository<Message>{
    void Update(Message message);

}