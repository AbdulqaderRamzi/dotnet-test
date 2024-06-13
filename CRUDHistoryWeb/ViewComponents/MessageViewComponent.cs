using CRUDHistory.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUDHistoryWeb.ViewComponents;
using Microsoft.AspNetCore.Mvc;

public class MessageViewComponent : ViewComponent{
    private readonly ApplicationDbContext _db;

    public MessageViewComponent(ApplicationDbContext db) => _db= db;

    public async Task<IViewComponentResult> InvokeAsync(string? receiverEmail)
    {
        var messages = await _db.Messages
            .Where(m => m.RecipientEmail == receiverEmail && !m.Seen).Include("applicationUser")
            .OrderByDescending(m => m.SentAt).ToListAsync();
        return View(messages);
    }
}
