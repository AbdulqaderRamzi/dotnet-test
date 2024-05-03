﻿using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;
using CRUDHistory.Models.ViewsModels;
using CRUDHistory.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class EmployeeController : Controller{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public EmployeeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment){
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

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
    public IActionResult Upsert(EmploteeVM employeeVm, IFormFile? file){
        if (!ModelState.IsValid){
            employeeVm.TagList = _unitOfWork.Tag.GetAll()
                .Select(u => new SelectListItem{
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            return View(employeeVm);
        }
        var wwwRootPath = _webHostEnvironment.WebRootPath;
        if (file is not null){
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var employeePath = Path.Combine(wwwRootPath, @"images\employees");
            using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create)) {
               file.CopyTo(fileStream);
            }
            //employeeVm.Employee.imageUrl = Path.Combine(employeePath, fileName);
            employeeVm.Employee.imageUrl = @"images\employees\" + fileName;
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