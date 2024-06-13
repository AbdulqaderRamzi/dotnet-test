using CRUDHistory.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDHistoryWeb.ViewComponents;

public class EmployeeViewComponent : ViewComponent{
    private readonly ApplicationDbContext _db;

    public EmployeeViewComponent(ApplicationDbContext db) => _db= db;

    public async Task<IViewComponentResult> InvokeAsync(string? id){
        var employee = await _db.ApplicationUsers.
                   FirstOrDefaultAsync(u => u.Id == id);
        
        return View("Default", employee?.FirstName);
    }
}