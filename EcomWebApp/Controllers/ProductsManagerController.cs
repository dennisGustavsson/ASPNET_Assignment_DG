using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Controllers;

[Authorize(Roles = "admin")]
public class ProductsManagerController : Controller
{

	#region constructors

    private readonly ProductService _productService;
    private readonly TagService _tagService;
    private readonly DataContext _context;
	public ProductsManagerController(ProductService productService, TagService tagService, DataContext context)
	{
		_productService = productService;
		_tagService = tagService;
		_context = context;
	}
	#endregion


	public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();
        return View(products);
    }

    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateProductAsync(productRegistrationViewModel))
                return RedirectToAction("Index", "ProductsManager");

            ModelState.AddModelError("", "Something went wrong, try again.");
        }

        return View(productRegistrationViewModel);
    }

	public IActionResult CreateTags()
	{
		return View();
	}

    [HttpPost]
    public async Task<IActionResult> CreateTags(CreateTagsViewModel model)
    {
        if(!await _context.Tags.AnyAsync())
        {
			await _tagService.CreateTagAsync("New");
			await _tagService.CreateTagAsync("Featured");
			await _tagService.CreateTagAsync("Popular");
			await _tagService.CreateTagAsync("On Sale");
		}
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

}
