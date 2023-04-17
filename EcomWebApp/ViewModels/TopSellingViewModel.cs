namespace EcomWebApp.ViewModels;

public class TopSellingViewModel
{
    public string? Title { get; set; }
    public IEnumerable<GridItemViewModel> GridItems { get; set; } = null!;
}
