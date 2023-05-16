using EcomWebApp.Helpers.Services;
using EcomWebApp.Models;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class HomeController : Controller
{

    private readonly ProductService _productService;
    private readonly ProductCategoryService _categoryService;

    public HomeController(ProductService productService, ProductCategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Home";

        //Get Featured
        var featured = await _productService.GetAllByTagsAsync("Featured");
        var featuredGridItems = featured.Select(product => new GridItemViewModel
        { Id = product.Id.ToString(),Title = product.Name,Price = product.Price,ImageUrl = product.HeroImageUrl} );

        // Get Categories
        var categories = await _categoryService.GetAllCategoriesAsync();



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
                GridItems = new List<GridItemViewModel>
                    {
                        new GridItemViewModel {Id = "9", Title = "A product", Price = 40, ImageUrl = "images/placeholders/369x310.svg"},
                        new GridItemViewModel {Id = "10", Title = "A product", Price = 40, ImageUrl = "images/placeholders/369x310.svg"},
                    },
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
                GridItems = new List<GridItemViewModel>
                    {
                        new GridItemViewModel {Id = "11", Title = "A cool product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "12", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "13", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "14", Title = "Pants", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "15", Title = "IPhone", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "16", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "17", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"}
                    }
            }

        };


        return View(viewModel);
    }
}
