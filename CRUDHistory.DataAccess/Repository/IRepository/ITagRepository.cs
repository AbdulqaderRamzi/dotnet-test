using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface ITagRepository : IRepository<Tag>{
    void Update(Tag tag);
}