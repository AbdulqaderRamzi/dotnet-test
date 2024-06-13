using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistory.Models;

public class ApplicationUser : IdentityUser {
    [Required] 
    public string FirstName{ get; set; }
    [Required] 
    public string LastName{ get; set; }
    [Required] 
    public string Career { get; set; }
    [Required] 
    public string Gender { get; set; }
    [Required]
    public int Salary{ get; set; }

    public string Language{ get; set; } = string.Empty; 
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateOnly DateOfBirth { get; set; }
    public string? StreetAddress{ get; set; }
    public string? City{ get; set; }
    public string State{ get; set; } = string.Empty;
    public string ImageUrl{ get; set; } = string.Empty;
  
}