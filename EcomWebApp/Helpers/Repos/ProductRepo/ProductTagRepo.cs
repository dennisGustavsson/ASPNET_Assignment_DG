using EcomWebApp.Contexts;
using EcomWebApp.Models.Entities;

namespace EcomWebApp.Helpers.Repos.ProductRepo;

public class ProductTagRepo : Repository<ProductTagEntity>
{
	public ProductTagRepo(DataContext context) : base(context)
	{
	}
}
