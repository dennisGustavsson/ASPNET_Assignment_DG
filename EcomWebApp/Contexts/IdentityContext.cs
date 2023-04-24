using EcomWebApp.Models.Entities;
using EcomWebApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> AspNetAddresses { get; set; }

    public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }



/*    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "System Administrator",
                NormalizedName = "SYSTEM ADMINISTRATOR"
            }
            );


        var passwordHasher = new PasswordHasher<AppUser>();
        builder.Entity<AppUser>().HasData(
            new AppUser
            {
                FirstName = "System",
                LastName = "Administrator",
                UserName = "administrator",
                PasswordHash = passwordHasher.HashPassword(null!,"BytMig123!"),
                
            });
    }*/
}
