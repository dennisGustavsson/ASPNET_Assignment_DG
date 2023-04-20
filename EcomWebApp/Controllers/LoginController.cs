using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
