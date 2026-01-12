using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Check (Contact contact)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");

            }
            return View();
        }
    }
}
