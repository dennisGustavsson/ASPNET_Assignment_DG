using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Repos.ProductRepo;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

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

/*	public async Task<Tag> GetTagsByProduct(int id)
	{
		var items = await _productTagRepo.GetAllAsync(x=>x.ProductId == id);


	}*/


}
