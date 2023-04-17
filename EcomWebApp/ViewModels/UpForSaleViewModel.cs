using EcomWebApp.Models;

namespace EcomWebApp.ViewModels;

public class UpForSaleViewModel
{
    public IEnumerable<GridItemViewModel> GridItems { get; set; } = null!;
    public UpForSaleModel UpForSale { get; set; } = null!;
}
