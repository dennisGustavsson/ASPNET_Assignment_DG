using EcomWebApp.Contexts;
using EcomWebApp.Models;
using EcomWebApp.Models.Identity;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Helpers.Services;

public class UsersService
{
	private readonly IdentityContext _identityContext;
	private readonly UserManager<AppUser> _userManager;

    public UsersService(IdentityContext identityContext, UserManager<AppUser> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserProfileCardViewModel>> GetAllAsync()
	{

		var usersProfiles = new List<UserProfileCardViewModel>();
		var users = await _identityContext.Users.Include(u => u.Addresses).ThenInclude(ua => ua.Address).ToListAsync();


		foreach (var _user in users)
		{
            UserProfileCardViewModel item = _user;

			item.Roles = await _userManager.GetRolesAsync(_user);

            usersProfiles.Add(item);
			
		};

	return usersProfiles;
	}

	public async Task DeleteUserAsync(AppUser user)
	{
		await _userManager.DeleteAsync(user);
	}
}
