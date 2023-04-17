using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
