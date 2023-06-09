﻿using EcomWebApp.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(TagId))]
public class ProductTagEntity
{
	public int ProductId { get; set; }
	public ProductEntity Product { get; set; } = null!;
	public int TagId { get; set; }
	public TagEntity Tag { get; set; } = null!;
}
