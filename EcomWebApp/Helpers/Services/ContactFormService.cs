using EcomWebApp.Contexts;
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

            /*			ContactFormSenderEntity contactFormSenderEntity = contactFormViewModel;
                        _contactFormContext.Senders.Add(contactFormSenderEntity);
                        await _contactFormContext.SaveChangesAsync();


                        ContactFormMessageEntity contactFormMessageEntity = contactFormViewModel;
                        contactFormMessageEntity.SenderId = contactFormSenderEntity.Id;


                        _contactFormContext.Messages.Add(contactFormMessageEntity);	
                        await _contactFormContext.SaveChangesAsync();*/
            return true;

        }
        catch { return false; }
    }
}
