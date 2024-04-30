namespace CRUDHistory.DataAccess.Repository.IRepository;
public interface IUnitOfWork{
    IEmployeeRepository Employee { get; }
    IProductRepository Product { get; }
    ITagRepository Tag{ get; }
    void Save();
}