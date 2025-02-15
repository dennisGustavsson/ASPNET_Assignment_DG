namespace EcomWebApp.Models;

public class ShoppingCartItem
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public int Quantity { get; set; } = 1;

}
