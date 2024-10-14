using EcomWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace EcomWebApp.Helpers.Services;

public class ShoppingCartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string SessionKey = "_ShoppingCart";

    public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }




    public List<ShoppingCartItem> GetCart()
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        if (session == null || session.GetString(SessionKey) == null)
        {
            return new List<ShoppingCartItem>(); // return empty cart if no session exists
        }

        // Deserialize shopping cart from session
        var data = session.GetString(SessionKey);
        return JsonSerializer.Deserialize<List<ShoppingCartItem>>(data!) ?? new List<ShoppingCartItem>();
    }

    public void AddToCart(ShoppingCartItem item)
    {
        var cart = GetCart();
        var existingItem = cart.FirstOrDefault(x => x.ProductId == item.ProductId);
        if (existingItem == null)
        {
            cart.Add(item);
        }
        else
        {
            existingItem.Quantity += item.Quantity;
        }
        SaveCart(cart);
    }

    public void SaveCart(List<ShoppingCartItem> cart)
    {
        var data = JsonSerializer.Serialize(cart);
        _httpContextAccessor.HttpContext!.Session.SetString(SessionKey, data);
    }
}
