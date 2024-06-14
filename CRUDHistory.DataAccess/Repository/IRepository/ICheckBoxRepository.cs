using CRUDHistory.Models;

namespace CRUDHistory.DataAccess.Repository.IRepository;

public interface ICheckBoxRepository : IRepository<CheckBox>{
    void Update(CheckBox checkBox);
}