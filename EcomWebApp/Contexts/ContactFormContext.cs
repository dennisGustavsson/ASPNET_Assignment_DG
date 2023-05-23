using EcomWebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Contexts
{
	public class ContactFormContext : DbContext
	{
		public ContactFormContext(DbContextOptions<ContactFormContext> options) : base(options)
		{
		}

		public DbSet<ContactFormSenderEntity> Senders { get; set; }

		public DbSet<ContactFormMessageEntity> Messages { get; set; }

		public DbSet<NewsletterEmailEntity> NewsletterEmails { get; set; }
	}
}
