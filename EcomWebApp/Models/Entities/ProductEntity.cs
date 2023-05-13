using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EcomWebApp.Models.Dtos;

namespace EcomWebApp.Models.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategoryEntity ProductCategory { get; set; } = null!;

    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();

    public string? HeroImageUrl { get; set; }
    public string? ExtraImageUrl { get; set; }

    public static implicit operator Product(ProductEntity entity)
    {

        if (entity != null)
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                ProductCategory = entity.ProductCategory,
                Description = entity.Description,
                Price = entity.Price,
                HeroImageUrl = entity.HeroImageUrl,
                ExtraImageUrl = entity.ExtraImageUrl,

            };
        }
        return null!;

    }
}
