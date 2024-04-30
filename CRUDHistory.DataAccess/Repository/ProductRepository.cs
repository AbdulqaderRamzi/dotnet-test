using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository{
    private readonly ApplicationDbContext _db;
    public ProductRepository(ApplicationDbContext db) : base(db){
        _db = db;
    }

    public void Update(Product product) => _db.Update(product);
}