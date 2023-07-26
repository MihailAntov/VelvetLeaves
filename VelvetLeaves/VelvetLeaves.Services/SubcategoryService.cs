

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.Services
{
	public class SubcategoryService : ISubcategoryService
	{

		private readonly VelvetLeavesDbContext _context;
        public SubcategoryService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(string name, int categoryId, string imageId)
		{
			var subcategory = new Subcategory()
			{
				Name = name,
				CategoryId = categoryId,
				ImageId = imageId
			};

			await _context.Subcategories.AddAsync(subcategory);
			await _context.SaveChangesAsync();


		}

        public async Task<IEnumerable<SubcategorySelectViewModel>> AllSubcategoriesAsync()
        {
			var subcategories = await _context.Subcategories
				.Select(sc => new SubcategorySelectViewModel()
				{
					Id = sc.Id,
					Name = sc.Name
				}).ToArrayAsync();

			return subcategories;
        }

        public async Task<IEnumerable<SubcategorySelectViewModel>> SubcategoriesByCategoryIdAsync(int categoryId)
        {
			var subcategories = await _context.Subcategories
				.Where(s=> s.CategoryId == categoryId)
				.Select(sc => new SubcategorySelectViewModel()
				{
					Id = sc.Id,
					Name = sc.Name
				}).ToArrayAsync();

			return subcategories;
		}
    }
}
