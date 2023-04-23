using EcomWebApp.Helpers.Services;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class LoginController : Controller
{

    private readonly AuthenticationService _auth;

    public LoginController(AuthenticationService auth)
    {
        _auth = auth;
    }

    public IActionResult Index(string ReturnUrl = null!)
    {
        var viewModel = new LoginViewModel();
        if(ReturnUrl != null!)
            viewModel.ReturnUrl = ReturnUrl;

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel viewModel)
    {
        if(ModelState.IsValid)
        {
            if(await _auth.LoginAsync(viewModel))
                return LocalRedirect(viewModel.ReturnUrl);

            ModelState.AddModelError("", "Incorrect email or password.");
        }

        return View(viewModel);
    }
}
