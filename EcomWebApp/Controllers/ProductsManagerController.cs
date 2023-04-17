using EcomWebApp.Services;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers;

public class ProductsManagerController : Controller
{
    private readonly ProductService _productService;

    public ProductsManagerController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
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
            if (await _productService.CreateAsync(productRegistrationViewModel))
                return RedirectToAction("Index", "ProductsManager");

            ModelState.AddModelError("", "Något gick fel vid skapandet av produkten");
        }

        return View(productRegistrationViewModel);
    }

}
