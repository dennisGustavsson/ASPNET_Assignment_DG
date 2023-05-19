using EcomWebApp.Models.Entities;
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
    public int ProductCategoryId { get; set; }

    [Required(ErrorMessage = "A price is required")]
    [Display(Name = "Price")]
    public decimal Price { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }

/*	[Display(Name = "Hero Image URL")]
    public string? HeroImageUrl { get; set; }

    [Display(Name = "Extra Image URL")]
    public string? ExtraImageUrl { get; set; }*/

    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        var entity =  new ProductEntity
        {
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            ProductCategoryId = productRegistrationViewModel.ProductCategoryId,
            Price = productRegistrationViewModel.Price,
/*            HeroImageUrl = productRegistrationViewModel.HeroImageUrl,
            ExtraImageUrl = productRegistrationViewModel.ExtraImageUrl,*/
        };

        if(productRegistrationViewModel.Image != null )
        {
            entity.HeroImageUrl = $"{productRegistrationViewModel.Name}_{productRegistrationViewModel.Image?.FileName}";
        }

        return entity;

    }
}
