using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDHistory.Models;

public class Product{
    public int Id{ get; set; }
    public string Name{ get; set; } = string.Empty;
    public string Type{ get; set; } = string.Empty;
    public int? Price{ get; set; }
    public DateTime DateTime{ get; set; } = DateTime.Now;

    public int EmployeeId{ get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee{ get; set; }// navigation property 
}