using EcomWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.ViewModels;

public class CreateTagsViewModel
{
	[Display(Name = "Tag Name*")]
	[Required(ErrorMessage = "You must enter a tag name")]
	public string TagName { get; set; } = null!;


	public static implicit operator TagEntity(CreateTagsViewModel model)
	{
		if(model != null)
		{
			return new TagEntity
			{
				TagName = model.TagName,
			};
		}
		return null!;
	}
}


