﻿using EcomWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.ViewModels;

public class ProductRegistrationViewModel
{

    [Required(ErrorMessage = "A name is required")]
    [Display(Name = "Product name")]
    public string Name { get; set; } = null!;


    [Display(Name = "Product description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "A category is required")]
    [Display(Name = "Product category")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "A price is required")]
    [Display(Name = "Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "A image url is required")]
    [Display(Name = "Hero Image URL")]
    public string HeroImageUrl { get; set; } = null!;

    [Display(Name = "Extra Image URL")]
    public string? ExtraImageUrl { get; set; }

    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        return new ProductEntity
        {
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            Category = productRegistrationViewModel.Category,
            Price = productRegistrationViewModel.Price,
            HeroImageUrl = productRegistrationViewModel.HeroImageUrl,
            ExtraImageUrl = productRegistrationViewModel.ExtraImageUrl,
        };

    }
}