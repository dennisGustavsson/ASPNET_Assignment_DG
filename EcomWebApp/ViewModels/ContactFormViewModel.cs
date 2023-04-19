using EcomWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.ViewModels;

public class ContactFormViewModel
{
	[Required(ErrorMessage = "A name is required")]
	public string Name { get; set; } = null!;

	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "An email address is required")]
	public string Email { get; set; } = null!;

	public string? PhoneNumber { get; set; }
	public string? CompanyName { get; set; }

	[Required(ErrorMessage = "A message is required")]
	public string Message { get; set; } = null!;
	

	public static implicit operator ContactFormSenderEntity(ContactFormViewModel model)
	{
		return new ContactFormSenderEntity
		{
			Name = model.Name,
			Email = model.Email,
			PhoneNumber = model.PhoneNumber,
			CompanyName = model.CompanyName,
		};
	}
	public static implicit operator ContactFormMessageEntity(ContactFormViewModel model)
	{
		return new ContactFormMessageEntity
		{
			Message = model.Message,
			SenderId = Guid.Empty,
		};


	}

}
