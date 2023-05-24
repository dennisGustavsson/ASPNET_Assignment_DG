using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Dtos;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductService _productService;
        private readonly ProductCategoryService _categoryService;
        private readonly DataContext _context;

		public ProductsController(ProductService productService, ProductCategoryService categoryService, DataContext context)
		{
			_productService = productService;
			_categoryService = categoryService;
			_context = context;
		}

		public async Task<IActionResult> Index(string? category)
        {

            var products = await _productService.GetAllByCategoryAsync(category);

            var gridItems = products.Select(product => new GridItemViewModel
            { Id = product.Id, Title = product.Name, Price = product.Price, ImageUrl = product.HeroImageUrl });
            GridCollectionViewModel viewModel = new()
            {
                Title = "All Products",
                Categories = await _categoryService.GetAllCategoriesAsync(),
                GridItems = gridItems,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetAsync(id);

			if (product == null)
			{
				RedirectToAction("Index");
			}

			var category = await _categoryService.GetAsync(product!.ProductCategoryId);
            var tags = await _context.ProductTags
                .Where(pt=>pt.ProductId == id)
                .Join(_context.Tags, pt => pt.TagId,
                t => t.Id, 
                (pt,t) => t.TagName).ToListAsync();
            var relatedProducts = await _productService.GetAllByCategoryAsync(product.ProductCategory.CategoryName, 4);
            var relatedProductsGridItems = relatedProducts.Select(product => new GridItemViewModel
            { Id = product.Id, Title = product.Name, Price = product.Price, ImageUrl = product.HeroImageUrl });

            ProductDetailsViewModel viewModel = new()
            {
                Product = new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    HeroImageUrl = product.HeroImageUrl,
                    ExtraImageUrl = product.ExtraImageUrl,
                    ProductCategory = category,
                    Description = product.Description,
                    Price = product.Price,
                    Tags = tags
                },
                RelatedProducts = new GridCollectionViewModel
                {
                    GridItems = relatedProductsGridItems,
                }


            };
            return View(viewModel);
        }
    }
}

