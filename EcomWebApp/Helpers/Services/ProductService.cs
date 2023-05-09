using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Repos.ProductRepo;
using EcomWebApp.Models;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace EcomWebApp.Helpers.Services;

public class ProductService
{
    private readonly ProductRepo _productRepo;

	public ProductService(ProductRepo productRepo)
	{
		_productRepo = productRepo;
	}


	public async Task<bool> CreateProductAsync(ProductRegistrationViewModel productRegistrationViewModel)
	{
		try
		{
			ProductEntity productEntity = productRegistrationViewModel;
			await _productRepo.AddAsync(productEntity);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public async Task<IEnumerable<Product>> GetAllAsync()
	{
		var products = new List<Product>();
		var items = await _productRepo.GetAllAsync();
		foreach (var item in items)
		{
			Product product = item;
			products.Add(product);
		};

		return products;
	}

	public async Task<Product> GetAsync(Guid id)
	{
		var item = await _productRepo.GetAsync(x => x.Id == id);

		return item;

	}
}
