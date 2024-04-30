using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface IEmployeeRepository : IRepository<Employee>{
    void Update(Employee employee);
}