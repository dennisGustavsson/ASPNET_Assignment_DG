using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcomWebApp.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductService _productService;
        private readonly ProductCategoryService _categoryService;
        private readonly TagService _tagService;
        private readonly ProductTagService _productTagService;
        private readonly DataContext _context;

		public ProductsController(ProductService productService, ProductCategoryService categoryService, TagService tagService, ProductTagService productTagService, DataContext context)
		{
			_productService = productService;
			_categoryService = categoryService;
			_tagService = tagService;
			_productTagService = productTagService;
			_context = context;
		}

		public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();

            return View(products);
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
                .Join(_context.Tags, pt => pt.TagId, t => t.Id, (pt,t) => t.TagName).ToListAsync();




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
                }

            };


            return View(viewModel);
        }
    }
}

/*            foreach(var tag in tags)
            {
                 await product.Tags.Add(tag);
            }*/

/*List<string> tags = await _tagService.GetAllAsync*/

/*			Expression<Func<ProductEntity, bool>> condition = p => p.Tags.Any(pt => pt.Tag.TagName == "tagName");
			var products = await _productService.GetAllAsync(condition);*/

