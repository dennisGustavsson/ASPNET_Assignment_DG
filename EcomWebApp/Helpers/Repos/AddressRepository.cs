using EcomWebApp.Contexts;
using EcomWebApp.Models.Entities;

namespace EcomWebApp.Helpers.Repos;

public class AddressRepository : Repository<AddressEntity>
{
    public AddressRepository(IdentityContext identityContext) : base(identityContext)
    {
    }
}
