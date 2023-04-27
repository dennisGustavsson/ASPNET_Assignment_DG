using EcomWebApp.Helpers.Services;
using EcomWebApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productService.GetAsync(id);
            if(product == null)
            {
                RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
