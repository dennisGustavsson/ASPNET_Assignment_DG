using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcomWebApp.Controllers;

[Authorize(Roles = "admin")]
public class ProductsManagerController : Controller
{

	#region constructors

    private readonly ProductService _productService;
    private readonly TagService _tagService;
	private readonly ProductCategoryService _productCategoryService;
    private readonly DataContext _context;
	public ProductsManagerController(ProductService productService, TagService tagService, DataContext context, ProductCategoryService productCategoryService)
	{
		_productService = productService;
		_tagService = tagService;
		_context = context;
		_productCategoryService = productCategoryService;
	}
	#endregion


	public async Task<IActionResult> Index()
    {
        if (!await _context.Tags.AnyAsync())
        {
            await _tagService.CreateTagAsync("New");
            await _tagService.CreateTagAsync("Featured");
            await _tagService.CreateTagAsync("Popular");
            await _tagService.CreateTagAsync("On Sale");
        }
        if (!await _context.ProductCategories.AnyAsync())
        {
            await _productCategoryService.CreateCategoryAsync("Laptops");
            await _productCategoryService.CreateCategoryAsync("PC");
            await _productCategoryService.CreateCategoryAsync("Monitors");
            await _productCategoryService.CreateCategoryAsync("Network");
            await _productCategoryService.CreateCategoryAsync("Multimedia");
            await _productCategoryService.CreateCategoryAsync("Gaming");

        }

        var products = await _productService.GetAllAsync();
        return View(products);
    }

    public async Task<IActionResult> Register()
    {
		ViewBag.Tags = await _tagService.GetAllAsync();
		ViewBag.Categories = await _productCategoryService.GetAllAsync();
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(ProductRegistrationViewModel viewModel, string[] tags)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateProductAsync(viewModel))
			{
				var product = await _productService.GetAsync(viewModel.Name);
				await _productService.AddTagsAsync(product, tags);
                return RedirectToAction("Index", "ProductsManager");
			}

            ModelState.AddModelError("", "Something went wrong, try again.");
        }

		ViewBag.Tags = await _tagService.GetAllAsync(tags);
        return View(viewModel);
    }

	public IActionResult CreateTags()
	{
		return View();
	}

    [HttpPost]
    public async Task<IActionResult> CreateTags(CreateTagsViewModel model)
    {

		if (ModelState.IsValid)
        {
			if (await _tagService.TagAlreadyExistAsync(model))
			{
				ModelState.AddModelError("", "A tag with this name already exist.");
				return View();
			}
			await _tagService.CreateTagAsync(model);
            return RedirectToAction("Register", "ProductsManager");
        }
        return View(model);
    }

	public IActionResult CreateCategory()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> CreateCategory(ProductCategoryViewModel model)
	{

		if (ModelState.IsValid)
		{
			if (await _productCategoryService.CategoryAlreadyExistAsync(model))
			{
				ModelState.AddModelError("", "A category with this name already exist.");
				return View();
			}
			await _productCategoryService.CreateCategoryAsync(model);
			return RedirectToAction("Register", "ProductsManager");
		}
		return View(model);
	}

}
