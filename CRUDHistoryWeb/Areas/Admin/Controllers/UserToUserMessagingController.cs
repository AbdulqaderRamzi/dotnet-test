using System.Security.Claims;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;
using CRUDHistory.Utility;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class UserToUserMessagingController : Controller{
    private readonly IUnitOfWork _unitOfWork;

    public UserToUserMessagingController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }

    public IActionResult SendMessage(){
        return View();
    }

    [HttpPost]
    public IActionResult SendMessage(Message message){
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(SendMessage));
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        message.SenderId = userId;
        message.Seen = false;
        message.RecipientEmail = message.RecipientEmail.ToLower().Trim();
        _unitOfWork.UserMessage.Add(message);
        _unitOfWork.Save();
        TempData["success"] = "The message has sent successfully";
        return RedirectToAction(nameof(SendMessage));
    }
}