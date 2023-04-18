using EcomWebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace EcomWebApp.Contexts
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
