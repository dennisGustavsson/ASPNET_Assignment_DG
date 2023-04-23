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



    public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
    }

    public async Task<bool> UserAlreadyExistAsync(UserRegistrationViewModel viewModel)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email);
    }

    public async Task<bool> RegisterUserAsync(UserRegistrationViewModel viewModel)
    {
        AppUser appUser = viewModel;

        var result = await _userManager.CreateAsync(appUser, viewModel.Password);
        if (result.Succeeded)
        {
            var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
            if(addressEntity != null)
            {
                await _addressService.AddAddressAsync(appUser,addressEntity);
                return true;
            }
        }
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
