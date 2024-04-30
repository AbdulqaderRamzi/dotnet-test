using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;
using CRUDHistory.Models.ViewsModels;
using CRUDHistory.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class EmployeeController : Controller{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public IActionResult Index(){
        var employees = _unitOfWork.Employee.GetAll().ToList();
        return View(employees);
    }

    public IActionResult Upsert(int? id){
        var employeeVm = new EmploteeVM {
            TagList = _unitOfWork.Tag.GetAll().
                Select(u => new SelectListItem {
                    Text = u.Name, 
                    Value = u.Id.ToString()
                }),
            Employee = id is null or 0 ? new () :
                _unitOfWork.Employee.Get(u => u.Id == id)
        };
        return View(employeeVm);
    }

    [HttpPost]
    public IActionResult Upsert(EmploteeVM employeeVm){
        if (!ModelState.IsValid){
            employeeVm.TagList = _unitOfWork.Tag.GetAll()
                .Select(u => new SelectListItem{
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            return View(employeeVm);
        }
        employeeVm.Employee.Email = employeeVm.Employee.Email.ToLower();
        if (employeeVm.Employee.Id == 0){
            _unitOfWork.Employee.Add(employeeVm.Employee);
            TempData["success"] = "Employee was added successfully";
        }
        else{
            _unitOfWork.Employee.Update(employeeVm.Employee);
            TempData["success"] = "Employee was updated successfully";
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    /*public IActionResult Delete(int? id){
        if (id is null or 0)
            return NotFound();
        var employee = _unitOfWork.Employee.Get(u => u.Id == id);
    }*/

    public IActionResult Delete(Employee employee){
        _unitOfWork.Employee.Remove(employee);
        _unitOfWork.Save();
        TempData["success"] = "Employee is deleted successfully";
        return RedirectToAction(nameof(Index));
    }
}