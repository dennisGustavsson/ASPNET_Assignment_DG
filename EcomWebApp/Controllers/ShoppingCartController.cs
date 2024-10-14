using EcomWebApp.Helpers.Services;
using EcomWebApp.Models;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class ShoppingCartController : Controller
{
    private readonly ShoppingCartService _shoppingCartService;

    public ShoppingCartController(ShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    public IActionResult Index()
    {
        var model = new ShoppingCartViewModel
        {
            Cart = _shoppingCartService.GetCart()
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult AddToCart(ProductDetailsViewModel viewModel)
    {
        if(viewModel.ShoppingCartItem is not null)
        {
            var result = _shoppingCartService.AddToCart(viewModel.ShoppingCartItem);
            if (result.IsSuccess)
            {
                return RedirectToAction("Details", "Products", new { id = viewModel.ShoppingCartItem.ProductId });
            }

            return View("Details", viewModel.ShoppingCartItem.ProductId);
        }
        return View("Details", viewModel.ShoppingCartItem!.ProductId);

    }

    [HttpGet]
    public IActionResult GetCart()
    {
        var cart = _shoppingCartService.GetCart();

        var viewModel = new ShoppingCartViewModel
        {
            Cart = cart
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int productId)
    {
        _shoppingCartService.RemoveFromCart(productId);
        return RedirectToAction("Index");
    }
}
