using EcomWebApp.Models;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";



        var viewModel = new HomeIndexViewModel
        {
            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bags", "Dresses", "Decorations", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },

                GridItems = new List<GridItemViewModel>
                    {
                        new GridItemViewModel {Id = "1", Title = "A cool product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "2", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "3", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "4", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "5", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "6", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "7", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                        new GridItemViewModel {Id = "8", Title = "A product", Price = 40, ImageUrl = "images/placeholders/270x295.svg"},
                    }
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
