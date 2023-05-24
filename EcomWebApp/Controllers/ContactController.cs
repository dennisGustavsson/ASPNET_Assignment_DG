using EcomWebApp.Helpers.Services;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcomWebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactFormService _contactFormService;

		public ContactController(ContactFormService contactFormService)
		{
			_contactFormService = contactFormService;
		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel contactFormViewModel)
        {
            if(ModelState.IsValid)
            {
                if(await _contactFormService.PostContactForm(contactFormViewModel))
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Message couldnt be posted");
            }
            return View(contactFormViewModel);
        }
    }
}
