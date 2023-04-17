namespace EcomWebApp.ViewModels;

public class HomeIndexViewModel
{
    public GridCollectionViewModel BestCollection { get; set; } = null!;
    public UpForSaleViewModel UpForSale { get; set; } = null!;
    public TopSellingViewModel TopSales { get; set; } = null!;
}
