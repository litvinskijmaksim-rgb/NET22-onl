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
    public IActionResult InventorySummary()
    {
        
        var products = InventoryRepository.GetAll();

        
        decimal totalValue = products.Sum(p => p.Price * p.Quantity);

       
        var categories = new Dictionary<string, decimal>();
        foreach (var p in products)
        {
            var cost = p.Price * p.Quantity;
            if (categories.ContainsKey(p.Category))
                categories[p.Category] += cost;
            else
                categories[p.Category] = cost;
        }

        
        ViewBag.Products = products;
        ViewBag.TotalValue = totalValue;
        ViewBag.Categories = categories;
        ViewBag.ProductCount = products.Count;

        return View();
    }
}