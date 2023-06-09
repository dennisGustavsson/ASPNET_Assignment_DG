﻿using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Repos.ProductRepo;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Helpers.Services;

public class ProductCategoryService
{

	private readonly ProductCategoryRepo _categoryRepo;
	private readonly DataContext _context;

	public ProductCategoryService(ProductCategoryRepo categoryRepo, DataContext context)
	{
		_categoryRepo = categoryRepo;
		_context = context;
	}

	public async Task<bool> CategoryAlreadyExistAsync(ProductCategoryViewModel model)
	{
		return await _context.ProductCategories.AnyAsync(x => x.CategoryName == model.CategoryName);
	}

	public async Task<ProductCategory> CreateCategoryAsync(ProductCategoryViewModel model)
	{

		var result = await _categoryRepo.AddAsync(new ProductCategoryEntity { CategoryName = model.CategoryName });
		return result;

	}
	public async Task<ProductCategory> CreateCategoryAsync(string categoryName)
	{

		var result = await _categoryRepo.AddAsync(new ProductCategoryEntity { CategoryName = categoryName });
		return result;

	}
	public async Task<IEnumerable<ProductCategory>> GetAllAsync()
	{
		var categories = new List<ProductCategory>();
		var result = await _categoryRepo.GetAllAsync();
		foreach (var category in result)
		{
			categories.Add(category);
		}
		return categories;

	}
    public async Task<IEnumerable<string>> GetAllCategoriesAsync()
    {
        var categories = new List<string>();
        var result = await _categoryRepo.GetAllAsync();
        foreach (var category in result)
        {
            categories.Add(category.CategoryName);
        }
        return categories;
    }

    public async Task<ProductCategory> GetAsync(int id)
    {
        var item = await _categoryRepo.GetAsync(x => x.Id == id);

        return item;
    }
}
