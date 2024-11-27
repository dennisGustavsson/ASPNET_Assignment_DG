using EcomWebApp.Models;

namespace EcomWebApp.ViewModels;

public class ShoppingCartViewModel
{
    public List<ShoppingCartItem> Cart { get; set; } = new List<ShoppingCartItem>();

    public int ItemCount { get; set; }
}
