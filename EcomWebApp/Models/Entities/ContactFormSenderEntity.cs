using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.Models.Entities;

public class ContactFormSenderEntity
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string? PhoneNumber { get; set; }
	public string? CompanyName { get; set; }

	public ICollection<ContactFormMessageEntity> Messages { get; set; } = new  List<ContactFormMessageEntity>();

}
