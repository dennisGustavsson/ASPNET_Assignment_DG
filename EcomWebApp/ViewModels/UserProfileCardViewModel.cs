using EcomWebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace EcomWebApp.ViewModels;


public class UserProfileCardViewModel
{
	public string UserId { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string? CompanyName { get; set; }
	public string? ProfileImage { get; set; }

	public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
	public ICollection<string> Roles { get; set; } = new List<string>();
}
