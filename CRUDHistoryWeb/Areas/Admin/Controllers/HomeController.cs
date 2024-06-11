using System.Diagnostics;
using CRUDHistory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class HomeController : Controller{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;
    

    public IActionResult Index(){
        return View();
    }
    
    [AllowAnonymous]
    public IActionResult Welcome()
    {
        if (User.Identity.IsAuthenticated) 
             return RedirectToAction(nameof(Index));
        return RedirectToPage("/Account/Login", new { area = "Identity" });
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel{ RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}