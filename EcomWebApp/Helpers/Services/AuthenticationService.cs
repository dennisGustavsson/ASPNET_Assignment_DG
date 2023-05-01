using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Identity;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Helpers.Services;

public class AuthenticationService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly AddressService _addressService;
    private readonly RoleManager<IdentityRole> _roleManager;


	public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<bool> UserAlreadyExistAsync(UserRegistrationViewModel viewModel)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email);
    }

    public async Task<bool> RegisterUserAsync(UserRegistrationViewModel viewModel)
    {
        try
        {
            AppUser appUser = viewModel;

            var roleName = "user";

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);

                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }
            }
        } catch { }
        return false;
    }


    public async Task<bool> LoginAsync(LoginViewModel viewModel)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
        if(appUser != null)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, viewModel.Password, viewModel.RememberMe, false);
            return result.Succeeded;
        }

        return false;
    }
}
