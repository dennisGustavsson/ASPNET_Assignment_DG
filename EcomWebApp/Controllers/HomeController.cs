using EcomWebApp.Helpers.Services;
using EcomWebApp.Models;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class HomeController : Controller
{

    private readonly ProductService _productService;
    private readonly ProductCategoryService _categoryService;
    private readonly ContactFormService _contactFormService;

	public HomeController(ProductService productService, ProductCategoryService categoryService, ContactFormService contactFormService)
	{
		_productService = productService;
		_categoryService = categoryService;
		_contactFormService = contactFormService;
	}

	public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Home";


        #region get products from database 

        //Get Featured
        var featured = await _productService.GetAllByTagsAsync("Featured", 4);
        var featuredGridItems = featured.Select(product => new GridItemViewModel
        { Id = product.Id,Title = product.Name,Price = product.Price,ImageUrl = product.HeroImageUrl} );

        // Get Categories
        var categories = await _categoryService.GetAllCategoriesAsync();

        //Get Up for sale
        var onSale = await _productService.GetAllByTagsAsync("On Sale", 2);
        var onsaleGridItems = onSale.Select(product => new GridItemViewModel
        { Id = product.Id, Title = product.Name, Price = product.Price, ImageUrl = product.HeroImageUrl });

        //Get Top Selling (Popular)
        var popular = await _productService.GetAllByTagsAsync("Popular", 7);
        var popularGridItems = popular.Select(product => new GridItemViewModel
        { Id = product.Id, Title = product.Name, Price = product.Price, ImageUrl = product.HeroImageUrl });

        #endregion

        var viewModel = new HomeIndexViewModel
        {
            Featured = new GridCollectionViewModel
            {
                Title = "Featured",
                Categories = categories,
                GridItems = featuredGridItems,
            },
            UpForSale = new UpForSaleViewModel
            {
                GridItems = onsaleGridItems,
                UpForSale = new UpForSaleModel
                {
                    RedTitle = "UP FOR SALE",
                    Title = "50% OFF",
                    Ingress = "Get the Best Price",
                    Description = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
                    LinkUrl = "/products"
                }
            },
            TopSales = new TopSellingViewModel
            {
                Title = "Top Selling Products This Week",
                GridItems = popularGridItems,
            }


        };


        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> SubscribeToNewsletter(NewsletterViewModel model)
    {
		if (ModelState.IsValid)
		{
			await _contactFormService.AddNewsletterEmailAsync(model);
			return RedirectToAction("Index");
		}
		ModelState.AddModelError("", "Message couldnt be posted");
		return View(model);
	}
}
