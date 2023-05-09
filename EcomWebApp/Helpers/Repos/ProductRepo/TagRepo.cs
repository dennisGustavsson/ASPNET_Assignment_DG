using EcomWebApp.Contexts;
using EcomWebApp.Models.Entities;

namespace EcomWebApp.Helpers.Repos.ProductRepo
{
	public class TagRepo : Repository<TagEntity>
	{
		public TagRepo(DataContext context) : base(context)
		{
		}
	}
}
