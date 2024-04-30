using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class TagController : Controller{
    private readonly IUnitOfWork _unitOfWork;

    public TagController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;

    }
    public IActionResult Index(){
        var tags = _unitOfWork.Tag.GetAll().ToList();
        return View(tags);
    }

    public IActionResult Upsert(int? id){
        if (id is null or 0)
            return View(new Tag());
        var tag = _unitOfWork.Tag.Get(u => u.Id == id);
        return View(tag);
    }

    [HttpPost]
    public IActionResult Upsert(Tag tag){
        if (!ModelState.IsValid)
            return View(tag);
        if (tag.Id is 0)
            _unitOfWork.Tag.Add(tag);
        else 
            _unitOfWork.Tag.Update(tag);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }
}