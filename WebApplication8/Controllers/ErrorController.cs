using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            // Простая страница с извинениями
            return View();
        }
    }
}