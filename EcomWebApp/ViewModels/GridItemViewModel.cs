﻿namespace EcomWebApp.ViewModels;

public class GridItemViewModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;
    public decimal Price { get; set; }
}
