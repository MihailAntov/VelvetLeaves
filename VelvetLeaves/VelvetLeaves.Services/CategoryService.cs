

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
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

        public async Task AddCategoryAsync(string categoryName, string imageId)
        {
            var category = new Category
            {
                Name = categoryName,
                ImageId = imageId
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategorySelectViewModel>> AllCategoriesAsync()
        {
            var categories = await _context
                .Categories
                .Select(c => new CategorySelectViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    //ImageUrl = c.ImageUrl
                }).ToArrayAsync();

            return categories;
        }

        public async Task<int> GetDefaultCategoryIdAsync()
        {
            var id = await _context.Categories
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            return id;
        }
    }
}
