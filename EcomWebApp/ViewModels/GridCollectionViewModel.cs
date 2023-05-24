namespace EcomWebApp.ViewModels;

public class GridCollectionViewModel
{
    public string Title { get; set; } = "";

    public IEnumerable<string>? Categories { get; set; }

    public IEnumerable<GridItemViewModel> GridItems { get; set; } = null!;

    public bool LoadMore { get; set; } = false;
}
