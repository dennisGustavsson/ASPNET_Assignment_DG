using EcomWebApp.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
public class NewsletterEmailEntity
{
	public int Id { get; set; }
	public string Email { get; set; } = null!;


	public static implicit operator NewsletterEmail(NewsletterEmailEntity entity)
	{
		if(entity != null)
		{
			return new NewsletterEmail
			{
				Email = entity.Email,
			};
		}
		return null!;
	}
}


