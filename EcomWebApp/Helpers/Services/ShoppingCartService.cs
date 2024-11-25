using EcomWebApp.Contexts;
using EcomWebApp.Models;
using FluentResults;
using System.Text.Json;

namespace EcomWebApp.Helpers.Services;

public class ShoppingCartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _context;
    //TODO  add a session key bound to the specific user
    private const string SessionKey = "_ShoppingCart";

    public ShoppingCartService(IHttpContextAccessor httpContextAccessor, DataContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }

    public List<ShoppingCartItem> GetCart()
    {
        // Get current session
        var session = _httpContextAccessor.HttpContext?.Session;
        if (session == null || session.GetString(SessionKey) == null)
        {

            return new List<ShoppingCartItem>(); // return empty cart if no session exists
        }

        // Deserialize shopping cart from session
        var data = session.GetString(SessionKey);
        var list = JsonSerializer.Deserialize<List<ShoppingCartItem>>(data!) ?? new List<ShoppingCartItem>();
        foreach (var item in list)
        {
            var product = _context.Products.Find(item.ProductId);
            if (product != null)
            {
                item.ProductName = product.Name;
                item.Price = product.Price;
            }
        }
        return list;
    }


    public Result AddToCart(ShoppingCartItem item)
    {
        if(item == null)
        {
            return Result.Fail("Product not found");
        }

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
        return Result.Ok();
    }

    public void SaveCart(List<ShoppingCartItem> cart)
    {
        var data = JsonSerializer.Serialize(cart);
        _httpContextAccessor.HttpContext!.Session.SetString(SessionKey, data);
    }

    //TODO add a method to remove an item from the cart

    public void RemoveFromCart(int productId)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.ProductId == productId);
        if (item != null)
        {
            cart.Remove(item);
            SaveCart(cart);
        }
    }
    public int GetCartCount()
    {
        var cart = GetCart();
        return cart.Count;
    }

    public void IncrementQuantity(int productId)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.ProductId == productId);
        if (item != null)
        {
            item.Quantity++;
            SaveCart(cart);
        }
    }

    public void DecrementQuantity(int productId)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.ProductId == productId);
        if (item != null)
        {
            item.Quantity--;
            if (item.Quantity == 0)
            {
                cart.Remove(item);
            }
            SaveCart(cart);
        }
    }
}
