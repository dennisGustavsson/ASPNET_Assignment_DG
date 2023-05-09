using EcomWebApp.Contexts;
using EcomWebApp.Models.Entities;

namespace EcomWebApp.Helpers.Repos.ProductRepo
{
	public class ProductRepo : Repository<ProductEntity>
	{
		public ProductRepo(DataContext context) : base(context)
		{
		}
	}
}
