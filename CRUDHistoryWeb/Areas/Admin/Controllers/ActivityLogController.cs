using System.Security.Claims;
using CRUDHistory.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class ActivityLogController : Controller{
    private readonly IUnitOfWork _unitOfWork;

    public ActivityLogController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index(){
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        var activities = _unitOfWork.ActivityLog
            .GetAll(u => u.ApplicationUserId == userId).ToList();
        return View(activities);
    }
}