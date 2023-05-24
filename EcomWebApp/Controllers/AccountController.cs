using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Entities;
using EcomWebApp.Models.Identity;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Controllers;



[Authorize]
public class AccountController : Controller
{

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly AddressService _addressService;
    private readonly IdentityContext _identityContext;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AddressService addressService, IdentityContext identityContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _addressService = addressService;
        _identityContext = identityContext;
    }

    public async Task<IActionResult> Index()
    {

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return null!;
        }

        var userAddress = await _identityContext.AspNetUsersAddresses
            .Include(ua => ua.Address)
            .Where(ua => ua.UserId == user.Id)
            .Select(ua => ua.Address)
            .FirstOrDefaultAsync();

        var model = new UserProfileCardViewModel
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            CompanyName = user.CompanyName,
            ProfileImage = user.ProfileImage,
            Addresses = userAddress != null ? new List<UserAddressEntity> { new UserAddressEntity { Address = userAddress } } : new List<UserAddressEntity>(),

        };

        return View(model);

    }
}
