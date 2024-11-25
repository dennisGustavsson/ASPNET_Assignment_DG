namespace EcomWebApp.Models.Dtos;

public class Product
{

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ProductCategory ProductCategory { get; set; } = null!;
    public int ProductCategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? HeroImageUrl { get; set; }
    public string? ExtraImageUrl { get; set; }
    public IEnumerable<string>? Tags { get; set; }

    public int Quantity { get; set; }
}
