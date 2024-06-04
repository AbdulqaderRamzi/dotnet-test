using CRUDHistory.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using CRUDHistory.Models;


namespace CRUDHistoryWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public IActionResult Index(){
        var products = _unitOfWork.Product.GetAll().ToList();
        return View(products);
    }

    public IActionResult Upsert(int? id){
        if (id is null or 0)
            return View(new Product());
        var product = _unitOfWork.Product.Get(u => u.Id == id);
        return View(product);
    }   

    [HttpPost]
    public IActionResult Upsert(Product product){
        if (!ModelState.IsValid) return View(product);
        if (product.Id == 0){
            _unitOfWork.Product.Add(product);
            TempData["success"] = "Product was added successfully";
        }
        else{
            _unitOfWork.Product.Update(product);
            TempData["success"] = "Product was updated successfully";
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }
    
}