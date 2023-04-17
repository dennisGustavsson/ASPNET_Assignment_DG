using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
