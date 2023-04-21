using EcomWebApp.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Models.Entities;


[PrimaryKey(nameof(UserId), nameof(AddressId))]
public class UserAddressEntity
{
    public string UserId { get; set; } = null!;
    public int AddressId { get; set; }

    public AppUser User { get; set; } = null!;
    public AddressEntity Address { get; set; } = null!;
}
