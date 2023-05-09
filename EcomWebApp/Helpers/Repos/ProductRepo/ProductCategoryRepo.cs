using EcomWebApp.Contexts;
using EcomWebApp.Models.Entities;

namespace EcomWebApp.Helpers.Repos.ProductRepo;

public class ProductCategoryRepo : Repository<ProductCategoryEntity>
{
	public ProductCategoryRepo(DataContext context) : base(context)
	{
	}
}
