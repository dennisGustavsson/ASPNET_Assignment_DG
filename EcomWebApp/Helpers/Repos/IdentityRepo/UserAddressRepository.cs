using EcomWebApp.Contexts;
using EcomWebApp.Models.Entities;

namespace EcomWebApp.Helpers.Repos.IdentityRepo;

public class UserAddressRepository : Repository<UserAddressEntity>
{
    public UserAddressRepository(IdentityContext identityContext) : base(identityContext)
    {
    }
}
