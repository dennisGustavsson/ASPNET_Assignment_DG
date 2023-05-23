using EcomWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.ViewModels;

public class NewsletterViewModel
{
	[DataType(DataType.EmailAddress)]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,}(?:[^\W_]|-)*$",
	ErrorMessage = "Characters are not allowed.")]
	[Required(ErrorMessage = "An email address is required")]
	public string Email { get; set; } = null!;


	public static implicit operator NewsletterEmailEntity(NewsletterViewModel model)
	{
		if(model != null)
		{
			return new NewsletterEmailEntity { Email = model.Email, };
		}
		return null!;
	}
}
