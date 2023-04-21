using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
