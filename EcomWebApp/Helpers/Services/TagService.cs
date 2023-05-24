using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Repos.ProductRepo;
using EcomWebApp.Models.Dtos;
using EcomWebApp.Models.Entities;
using EcomWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcomWebApp.Helpers.Services;

public class TagService
{


	private readonly TagRepo _tagRepo;
	private readonly DataContext _context;

	public TagService(TagRepo tagRepo, DataContext context)
	{
		_tagRepo = tagRepo;
		_context = context;
	}

	public async Task<bool> TagAlreadyExistAsync(CreateTagsViewModel model)
	{
		return await _context.Tags.AnyAsync(x => x.TagName == model.TagName);
	}

	public async Task<Tag> CreateTagAsync(string tagName)
	{

		var result = await _tagRepo.AddAsync(new TagEntity { TagName = tagName });
		return result;

	}
	public async Task<Tag> CreateTagAsync(CreateTagsViewModel model)
	{
		var result = await _tagRepo.AddAsync(new TagEntity { TagName = model.TagName });
		return result;
	}

	public async Task<Tag> GetAsync(string tagName)
	{
		var result = await _tagRepo.GetAsync(x=> x.TagName ==  tagName);
		return result;
	}

	public async Task<IEnumerable<SelectListItem>> GetAllAsync()
	{
		var tags = new List<SelectListItem>();
		
		foreach(var tag in await _tagRepo.GetAllAsync())
		{
			tags.Add(new SelectListItem
			{
				Value = tag.Id.ToString(),
				Text = tag.TagName
			});
		}
		return tags;
		
	}

	public async Task<IEnumerable<SelectListItem>> GetAllAsync(string[] selectedTags)
	{
		var tags = new List<SelectListItem>();

		foreach (var tag in await _tagRepo.GetAllAsync())
		{
			tags.Add(new SelectListItem
			{
				Value = tag.Id.ToString(),
				Text = tag.TagName,
				Selected = selectedTags.Contains(tag.Id.ToString())
			});
		}
		return tags;
	}

	public async Task<bool> DeleteTagAsync(string tagName)
	{
		var entity = await _tagRepo.GetAsync(x => x.TagName == tagName);
		return await _tagRepo.DeleteAsync(entity); 
	}

}
