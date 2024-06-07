using System.Security.Claims;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class ChatController : Controller{
    private readonly IUnitOfWork _unitOfWork;

    public ChatController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }
    public IActionResult JoinChat(){
        var claimsIdentity = (ClaimsIdentity) User.Identity;
        var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var firstName = _unitOfWork.AppUser.Get(u => u.Id == userId).FirstName;
        var lastName = _unitOfWork.AppUser.Get(u => u.Id == userId).LastName;
        return View(new UserConnection {Username = string.Concat(firstName, " ", lastName)});
    }

    [HttpPost]
    public IActionResult JoinChat(UserConnection conn){
        if (ModelState.IsValid) 
            return RedirectToAction(nameof(ChatRoom), conn);
        return View(nameof(JoinChat), conn);
    }
    
    public IActionResult ChatRoom(UserConnection userConnection) {
        return View(userConnection);
    }
}