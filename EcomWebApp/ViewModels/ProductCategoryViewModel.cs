using EcomWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.ViewModels;

public class ProductCategoryViewModel
{
	[Required]
	[MinLength(2)]
	public string CategoryName { get; set; } = null!;


	public static implicit operator ProductCategoryEntity(ProductCategoryViewModel model)
	{
		if(model != null)
		{
			return new ProductCategoryEntity
			{
				CategoryName = model.CategoryName,
			};
		}
		return null!;
	}
}
