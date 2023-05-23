using EcomWebApp.Contexts;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Helpers.Services;

public class ContactFormService
{

    private readonly ContactFormContext _contactFormContext;

    public ContactFormService(ContactFormContext contactFormContext)
    {
        _contactFormContext = contactFormContext;
    }

    public async Task<bool> PostContactForm(ContactFormViewModel contactFormViewModel)
    {
        try
        {

            ContactFormSenderEntity? senderEntity = await _contactFormContext.Senders.FirstOrDefaultAsync(x => x.Email == contactFormViewModel.Email);

            if (senderEntity == null)
            {
                senderEntity = contactFormViewModel;
                _contactFormContext.Senders.Add(senderEntity);
                await _contactFormContext.SaveChangesAsync();
            }

            ContactFormMessageEntity messageEntity = contactFormViewModel;
            messageEntity.SenderId = senderEntity.Id;

            _contactFormContext.Messages.Add(messageEntity);
            await _contactFormContext.SaveChangesAsync();

            return true;

        }
        catch { return false; }
    }

    public async Task AddNewsletterEmailAsync(NewsletterViewModel viewModel)
    {
		try
		{

			NewsletterEmailEntity? newletterEmail = await _contactFormContext.NewsletterEmails.FirstOrDefaultAsync(x => x.Email == viewModel.Email);

			if (newletterEmail == null)
			{
				newletterEmail = viewModel;
				_contactFormContext.NewsletterEmails.Add(newletterEmail);
				await _contactFormContext.SaveChangesAsync();

			}


		}
		catch {  }
	}
}
