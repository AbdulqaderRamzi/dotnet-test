using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CRUDHistory.Models;

public class Message
{
    public int Id { get; set; }
    public string? SenderId { get; set; }
    [ForeignKey("SenderId")] 
    [ValidateNever]
    public ApplicationUser applicationUser { get; set; }
    public string RecipientEmail{ get; set; }
    public string Content { get; set; }
    public DateTime SentAt{ get; set; } = DateTime.Now;
}
