using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository;

public class TagRepository: Repository<Tag>, ITagRepository{
    private readonly ApplicationDbContext _db;
    
    public TagRepository(ApplicationDbContext db) : base(db){
        _db = db;
    }

    public void Update(Tag tag) => _db.Tags.Update(tag);
}