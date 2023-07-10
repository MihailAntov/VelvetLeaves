

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly VelvetLeavesDbContext _context;
        public CategoryService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryListViewModel>> AllCategoriesAsync()
        {
            var categories = await _context
                .Categories
                .Select(c => new CategoryListViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                }).ToArrayAsync();

            return categories;
        }
    }
}
