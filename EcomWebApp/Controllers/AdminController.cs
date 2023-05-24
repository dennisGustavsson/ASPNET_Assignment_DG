using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Identity;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly UsersService _userService;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AuthenticationService _auth;

    public AdminController(UsersService userService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AuthenticationService auth)
    {
        _userService = userService;
        _userManager = userManager;
        _roleManager = roleManager;
        _auth = auth;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Users()
    {
        var users = await _userService.GetAllAsync();
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.AddToRoleAsync(user!, role);
        return RedirectToAction("Users");
    }
	[HttpPost]
	public async Task<IActionResult> RemoveRole(string userId, string role)
	{

		var user = await _userManager.FindByIdAsync(userId);
		await _userManager.RemoveFromRoleAsync(user!, role);
		return RedirectToAction("Users");
	}

    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if(user != null)
        {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction("users", "admin");
    }

    public IActionResult RegisterUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(UserRegistrationViewModel viewModel)
    {

        if (ModelState.IsValid)
        {
            if (await _auth.UserAlreadyExistAsync(viewModel))
            {
                ModelState.AddModelError("", "An account with this email already exists.");
                return View();
            }

            if (await _auth.RegisterUserAsync(viewModel))
                return RedirectToAction("users", "admin");

            return View();
        }

        ModelState.AddModelError("", "All required fields needs to be filled.");
        return View(viewModel);
    }
}
