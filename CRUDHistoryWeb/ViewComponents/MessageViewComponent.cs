using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDHistoryWeb.ViewComponents;
using Microsoft.AspNetCore.Mvc;

public class MessageViewComponent : ViewComponent{
    private readonly ApplicationDbContext _db;

    public MessageViewComponent(ApplicationDbContext db) => _db= db;

    public async Task<IViewComponentResult> InvokeAsync(string? receiverEmail)
    {
        var messages = await _db.Messages
            .Where(m => m.RecipientEmail == receiverEmail).Include("applicationUser")
            .OrderByDescending(m => m.SentAt).ToListAsync();
        return View(messages);
    }
}
