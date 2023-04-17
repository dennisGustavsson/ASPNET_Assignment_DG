using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.Models.Entities;

public class ProductEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public string HeroImageUrl { get; set; } = null!;
    public string? ExtraImageUrl { get; set; }

    public static implicit operator ProductModel(ProductEntity entity)
    {
        return new ProductModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Category = entity.Category,
            Description = entity.Description,
            Price = entity.Price,
            HeroImageUrl = entity.HeroImageUrl,
            ExtraImageUrl = entity.ExtraImageUrl,

        };
    }
}
