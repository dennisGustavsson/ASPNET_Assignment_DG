using EcomWebApp.Models;

namespace EcomWebApp.Helpers.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new()
    {
        new ShowcaseModel()
        {
            Ingress = "Welcome to the shop",
            Title = "Exclusive Chair Gold Collection",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Title = "SHOP NOW",
                Url = "/products"
            }
        },
        new ShowcaseModel()
        {
            Ingress = "SHOP SHOP SHOP!",
            Title = "Very Exclusive Products",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel
            {
                Title = "SHOP NOW",
                Url = "/products"
            }
        }
    };

    public ShowcaseModel GetLatestShowcase()
    {
        return _showcases.LastOrDefault()!;
    }
}
