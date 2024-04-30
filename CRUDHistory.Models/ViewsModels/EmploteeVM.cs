using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDHistory.Models.ViewsModels;

public class EmploteeVM{
    public Employee Employee{ get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> TagList { get; set; }
}