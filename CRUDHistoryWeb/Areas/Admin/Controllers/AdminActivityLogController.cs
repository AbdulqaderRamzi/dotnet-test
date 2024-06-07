using CRUDHistory.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminActivityLogController : Controller{
    private readonly IUnitOfWork _unitOfWork;

    public AdminActivityLogController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index(){
        var activities = _unitOfWork.ActivityLog.GetAll(includeProperties:"ApplicationUser");
        return View(activities);
    }   
}