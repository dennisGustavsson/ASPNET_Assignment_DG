using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EcomWebApp.Models.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? CompanyName { get; set; }
    public string? ProfileImage { get; set; }
    

    public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();

    public static implicit operator UserProfileCardViewModel(AppUser appUser)
    {
        return new UserProfileCardViewModel
        {
            UserId = appUser.Id,
            FirstName = appUser.FirstName,
            LastName = appUser.LastName,
            Email = appUser.Email!,
            CompanyName = appUser.CompanyName,
            ProfileImage = appUser.ProfileImage,
            Addresses = appUser.Addresses,
        };
    }
}
