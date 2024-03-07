using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models.Models;
using Microsoft.AspNetCore.Mvc;

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
        if (id is null or 0)
            return View(new Employee());
        var employee = _unitOfWork.Employee.Get(u => u.Id == id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Upsert(Employee employee){
        if (!ModelState.IsValid) return View(employee);
        employee.Email = employee.Email.ToLower();
        if (employee.Id == 0){
            _unitOfWork.Employee.Add(employee);
            TempData["success"] = "Employee was added successfully";
        }
        else{
            _unitOfWork.Employee.Update(employee);
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