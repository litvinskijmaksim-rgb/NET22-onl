using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

public class ProductController : Controller
{
    
    public IActionResult Index()
    {
        var products = InventoryRepository.GetAll();
        return View(products);
    }

    
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    public IActionResult Create(Product product)
    {
        InventoryRepository.Add(product);
        return RedirectToAction("Index");
    }

    
    public IActionResult Edit(int id)
    {
        var product = InventoryRepository.GetById(id);
        return View(product);
    }

    
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        InventoryRepository.Update(product);
        return RedirectToAction("Index");
    }

    
    public IActionResult Delete(int id)
    {
        InventoryRepository.Delete(id);
        return RedirectToAction("Index");
    }
}