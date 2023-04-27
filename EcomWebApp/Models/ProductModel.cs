namespace EcomWebApp.Models;

public class ProductModel
{

    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? HeroImageUrl { get; set; }
    public string? ExtraImageUrl { get; set; }
}
