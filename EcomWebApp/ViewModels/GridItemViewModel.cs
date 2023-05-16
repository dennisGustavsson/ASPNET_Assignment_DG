namespace EcomWebApp.ViewModels;

public class GridItemViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;
    public decimal Price { get; set; }
}
