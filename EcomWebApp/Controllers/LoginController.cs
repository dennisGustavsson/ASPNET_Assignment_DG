using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginViewModel viewModel)
    {
        if(ModelState.IsValid)
        {

        return View();
        }

        ModelState.AddModelError("", "Incorrect email or password.");
        return View(viewModel);
    }
}
