using EcomWebApp.Helpers.Services;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class RegisterController : Controller
{

    private readonly AuthenticationService _auth;

    public RegisterController(AuthenticationService auth)
    {
        _auth = auth;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
    {

        if(ModelState.IsValid)
        {
            if (await _auth.UserAlreadyExistAsync(viewModel))
            {
                ModelState.AddModelError("", "An account with this email already exists.");
                return View();
            }
            
            if (await _auth.RegisterUserAsync(viewModel))
                return RedirectToAction("index", "login");

            return View();
        }

        ModelState.AddModelError("", "All required fields needs to be filled.");
        return View(viewModel);
    }
}
