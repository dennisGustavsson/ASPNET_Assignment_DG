using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
