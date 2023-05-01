using EcomWebApp.Helpers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly UsersService _userService;

	public AdminController(UsersService userService)
	{
		_userService = userService;
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
}
