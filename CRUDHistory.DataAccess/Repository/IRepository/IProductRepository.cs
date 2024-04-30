using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>{
    void Update(Product product);
}