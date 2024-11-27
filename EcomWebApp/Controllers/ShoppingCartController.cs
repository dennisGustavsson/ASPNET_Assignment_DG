using EcomWebApp.Helpers.Services;
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
            Cart = _shoppingCartService.GetCart(),
            ItemCount = _shoppingCartService.GetCart().Count
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult AddToCart(ProductDetailsViewModel viewModel)
    {
        if(viewModel.ShoppingCartItem != null)
        {
            var result = _shoppingCartService.AddToCart(viewModel.ShoppingCartItem);

            if(result.IsSuccess)
            {
                return Json(new {success = true, message = "Product added to cart successfully" });
            }

            return Json(new { success = false, message = "failed to add product to the cart" });
        }
        return Json(new { success = false, message = "invalid product data" });


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

    [HttpGet]
    public IActionResult GetCartCount()
    {
        int itemCount = _shoppingCartService.GetCartCount();
        return Json(new { itemCount });
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int productId)
    {
        _shoppingCartService.RemoveFromCart(productId);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult IncrementQuantity(int productId)
    {
        _shoppingCartService.IncrementQuantity(productId);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DecrementQuantity(int productId)
    {
        _shoppingCartService.DecrementQuantity(productId);
        return RedirectToAction("Index");
    }


    // TODO ! ! ! ! ! ADD AJAX FOR SHOPPINGCART LOGICS IN FRONTEND
}
