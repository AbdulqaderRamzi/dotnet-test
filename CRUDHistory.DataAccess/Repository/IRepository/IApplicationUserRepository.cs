using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface IApplicationUserRepository : IRepository<ApplicationUser>{ 
    void Update(ApplicationUser applicationUser);
}