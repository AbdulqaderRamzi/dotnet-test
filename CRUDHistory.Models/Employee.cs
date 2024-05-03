using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CRUDHistory.Models;

public class Employee{
    [Key]
    public int Id{ get; set; }
    [MaxLength(30)]
    public string Name{ get; set; } = string.Empty;
    [Range(0, int.MaxValue, ErrorMessage = "The Salary field must be greater than 0.")]
    [Required]
    public int? Salary{ get; set; }
    [MaxLength(30)]
    public string Career{ get; set; } = string.Empty;
    [EmailAddress]
    public string Email{ get; set; } = string.Empty;
    [DisplayName("Date")]
    public DateTime DateTime{ get; set; } = DateTime.Now;
    public string imageUrl{ get; set; }
    [DisplayName("Tags")]
    public int TagId{ get; set; }
    [ForeignKey("TagId")]
    [ValidateNever]
    public Tag Tag{ get; set; }
}