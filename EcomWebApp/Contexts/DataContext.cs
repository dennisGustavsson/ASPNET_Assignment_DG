using EcomWebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Contexts;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<ProductEntity> Products { get; set; }

	public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

	public DbSet<TagEntity> Tags { get; set; }
	public DbSet<ProductTagEntity> ProductTags { get; set; }


}
