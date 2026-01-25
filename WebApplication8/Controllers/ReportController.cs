using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

public class ReportController : Controller
{
    
    public IActionResult TotalValue()
    {
        var products = InventoryRepository.GetAll();
        decimal total = 0;

        foreach (var p in products)
        {
            total += p.Price * p.Quantity;
        }

        ViewBag.Total = total;
        return View();
    }

    
    public IActionResult CategorySummary()
    {
        var products = InventoryRepository.GetAll();
        var categories = new Dictionary<string, decimal>();

        foreach (var p in products)
        {
            var cost = p.Price * p.Quantity;

            if (categories.ContainsKey(p.Category))
            {
                categories[p.Category] += cost;
            }
            else
            {
                categories[p.Category] = cost;
            }
        }

        return View(categories);
    }
}