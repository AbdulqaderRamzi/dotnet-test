using CRUDHistory.DataAccess.Data;
using CRUDHistory.Models;
using CRUDHistory.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.ADMIN_ROLE)]
public class EmployeeAccountController : Controller{
    private readonly ApplicationDbContext _db;

    public EmployeeAccountController(ApplicationDbContext db){
        _db = db;
    }

    public IActionResult Index(){
        var applicationUsers = _db.ApplicationUsers.ToList();
        return View(applicationUsers);
    }

    #region API CALL
    
    [HttpPost]
    public IActionResult LockUnlock(string? id)
    {
        if (string.IsNullOrEmpty(id))
            return Json(new { success = false, message = "Invalid user ID" });
        
        var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);

        if (user is null)
            return Json(new { success = false, message = "User not found" });
        
        var isLocked = user.LockoutEnd is not null && user.LockoutEnd > DateTime.Now;
        user.LockoutEnd = isLocked ? DateTime.Now : DateTime.Now.AddYears(1000);
        
        _db.SaveChanges();

        return Json(new { success = true, message = "Operation Success", isLocked = !isLocked });
    }
        

    #endregion
    
    /*
    public IActionResult LockUnlock(string? id){    
        var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
        
        if (user is null)
            return RedirectToAction(nameof(Index));
        if (user.LockoutEnd is not null && user.LockoutEnd > DateTime.Now)
            user.LockoutEnd = DateTime.Now;
        else
            user.LockoutEnd = DateTime.Now.AddYears(1000);

        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }*/
    
}