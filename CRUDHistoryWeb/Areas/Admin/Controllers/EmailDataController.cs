using CRUDHistory.Models;
using CRUDHistory.Utility.SendingEmails;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class EmailDataController : Controller{
    private readonly IEmailSender _emailSender;

    public EmailDataController(IEmailSender emailSender){
        _emailSender = emailSender;
    }
    public IActionResult Index(){
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(EmailData emailData){
        await _emailSender.SendEmailAsync(emailData);
        return View();
    }
}