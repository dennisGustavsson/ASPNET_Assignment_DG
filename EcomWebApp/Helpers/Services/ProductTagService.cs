using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Repos.ProductRepo;

namespace EcomWebApp.Helpers.Services;

public class ProductTagService
{
	private readonly ProductTagRepo _productTagRepo;
	private readonly DataContext _context;

	public ProductTagService(ProductTagRepo productTagRepo, DataContext context)
	{
		_productTagRepo = productTagRepo;
		_context = context;
	}
}
