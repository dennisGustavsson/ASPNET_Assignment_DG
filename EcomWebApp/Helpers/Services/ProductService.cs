using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Repos.ProductRepo;
using EcomWebApp.Models;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace EcomWebApp.Helpers.Services;

public class ProductService
{
    private readonly ProductRepo _productRepo;
	private readonly ProductTagRepo _productTagRepo;
	private readonly ProductCategoryRepo _productCategoryRepo;
	private readonly TagService _tagService;

	public ProductService(ProductRepo productRepo, ProductTagRepo productTagRepo, ProductCategoryRepo productCategoryRepo, TagService tagService)
	{
		_productRepo = productRepo;
		_productTagRepo = productTagRepo;
		_productCategoryRepo = productCategoryRepo;
		_tagService = tagService;
	}


	public async Task<bool> CreateProductAsync(ProductRegistrationViewModel model)
	{
		var _entity = await _productRepo.GetAsync(x=>x.Name == model.Name);
		if (_entity == null)
		{
			_entity = await _productRepo.AddAsync(model);
			if(_entity != null)
				return true;
        }
			return false;
	}

	public async Task AddTagsAsync(ProductEntity entity, string[] tags)
	{

            foreach (var tag in tags)
            {
                await _productTagRepo.AddAsync(new ProductTagEntity
                {
                    ProductId = entity.Id,
                    TagId = int.Parse(tag),
                });
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
	public async Task<IEnumerable<ProductEntity>> GetAllByTagsAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		return await _productRepo.GetAllAsync(expression);
/*		var products = new List<Product>();
		var items = await _productRepo.GetAllAsync();
		foreach (var item in items)
		{
			Product product = item;
			products.Add(product);
		};*/

		/*return products;*/
	}

	public async Task<ProductEntity> GetAsync(int id)
	{
		var item = await _productRepo.GetAsync(x => x.Id == id);

		return item;

	}
	public async Task<ProductEntity> GetAsync(string name)
	{
		var item = await _productRepo.GetAsync(x => x.Name == name);

		return item;

	}
}
