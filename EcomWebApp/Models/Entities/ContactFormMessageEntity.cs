using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.Models.Entities;

public class ContactFormMessageEntity
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();

	public string Message { get; set; } = null!;

	public DateTime Posted { get; set; } = DateTime.Now;

	public Guid SenderId { get; set; } 
	public ContactFormSenderEntity SenderEntity { get; set; } = null!;
}
