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

    #region constructors and private fields
    private readonly ProductRepo _productRepo;
	private readonly ProductTagRepo _productTagRepo;
	private readonly ProductCategoryRepo _productCategoryRepo;
	private readonly TagService _tagService;
	private readonly IWebHostEnvironment _webHostEnv;
	private readonly DataContext _context;

    public ProductService(ProductRepo productRepo,
		ProductTagRepo productTagRepo,
		ProductCategoryRepo productCategoryRepo,
		TagService tagService,
		DataContext context,
		IWebHostEnvironment webHostEnv)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
        _productCategoryRepo = productCategoryRepo;
        _tagService = tagService;
        _context = context;
        _webHostEnv = webHostEnv;
    }

	#endregion


	public async Task<Product> CreateProductAsync(ProductRegistrationViewModel model)
	{
		var _entity = await _productRepo.GetAsync(x => x.Name == model.Name);
		if (_entity == null)
		{
			_entity = await _productRepo.AddAsync(model);
			if (_entity != null)
			{
				var category = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == _entity.ProductCategoryId);
				_entity.ProductCategory = category!;
				return _entity;
			}
		}
		return null!;
	}


	public async Task AddTagsAsync(Product entity, string[] tags)
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
    public async Task<ProductEntity> GetAsync(int id)
    {
        var item = await _productRepo.GetAsync(x => x.Id == id);
        return item;
    }
    public async Task<Product> GetAsync(string name)
    {
        var item = await _productRepo.GetAsync(x => x.Name == name);
        return item;
    }

	public async Task<bool> UploadImageAsync(Product product, IFormFile image)
	{
            string imagePath = $"{_webHostEnv.WebRootPath}/images/products/{product.HeroImageUrl}";
            await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
			return true;
	}

    public async Task<IEnumerable<Product>> GetAllAsync()
	{
		var products = new List<Product>();
		var items = await _productRepo.GetAllAsync();
		foreach (var item in items)
		{
			Product product = item;
			var category = await _context.ProductCategories.FirstOrDefaultAsync(x=>x.Id == item.ProductCategoryId);
			product.ProductCategory = category!;
            products.Add(product);
		};
		return products;
	}

    public async Task<IEnumerable<Product>> GetAllByCategoryAsync(string? category)
    {
        var products = new List<Product>();

		if (category != null)
		{
            var _items = await _context.Products.Where(p => p.ProductCategory.CategoryName == category).ToListAsync();
            foreach (var item in _items)
            {
                Product product = item;
                products.Add(product);
            };
            return products;
        }
        var items = await _context.Products.ToListAsync();
        foreach (var item in items)
        {
            Product product = item;
            products.Add(product);
        };
        return products;

    }
    public async Task<IEnumerable<Product>> GetAllByCategoryAsync(string? category, int count)
    {
        var products = new List<Product>();

        if (category != null)
        {
            var _items = await _context.Products.Where(p => p.ProductCategory.CategoryName == category).Take(count).ToListAsync();
            foreach (var item in _items)
            {
                Product product = item;
                products.Add(product);
            };
            return products;
        }
        var items = await _context.Products.ToListAsync();
        foreach (var item in items)
        {
            Product product = item;
            products.Add(product);
        };
        return products;

    }

    public async Task<IEnumerable<Product>> GetAllByTagsAsync(string tagName)
	{
		var products = new List<Product>();
		var items = await _context.Products.Where(p => p.Tags.Any(p => p.Tag.TagName == tagName)).ToListAsync();
		foreach (var item in items)
		{
			Product product = item;
			products.Add(product);
		};
		return products;
	}

    public async Task<IEnumerable<Product>> GetAllByTagsAsync(string tagName, int count)
    {
        var products = new List<Product>();
        var items = await _context.Products.Where(p => p.Tags.Any(p => p.Tag.TagName == tagName))
			.Take(count)
			.ToListAsync();
        foreach (var item in items)
        {
            Product product = item;
            products.Add(product);
        };
        return products;
    }


}