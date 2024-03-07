using CRUDHistory.Models.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface ISolutionRepository : IRepository<Solution>{
    void Update(Solution solution);
}