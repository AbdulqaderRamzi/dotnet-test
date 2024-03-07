namespace CRUDHistory.DataAccess.Repository.IRepository;
public interface IUnitOfWork{
    IEmployeeRepository Employee { get; }
    ISolutionRepository Solution { get; }
    void Save();
}