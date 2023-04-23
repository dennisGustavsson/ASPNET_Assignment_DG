using EcomWebApp.Contexts;
using EcomWebApp.Models;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace EcomWebApp.Helpers.Services;

public class ProductService
{
    private readonly ProductsContext _productContext;

    public ProductService(ProductsContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<bool> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
    {
        try
        {
            ProductEntity productEntity = productRegistrationViewModel;

            _productContext.Products.Add(productEntity);
            await _productContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _productContext.Products.ToListAsync();
        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        };

        return products;
    }
}
