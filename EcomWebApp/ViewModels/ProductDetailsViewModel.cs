using EcomWebApp.Models;
using EcomWebApp.Models.Dtos;

namespace EcomWebApp.ViewModels;

public class ProductDetailsViewModel
{
    public Product Product { get; set; } = null!;

    public GridCollectionViewModel RelatedProducts { get; set; } = null!;

    public ShoppingCartItem ShoppingCartItem { get; set; } = null!;

}
