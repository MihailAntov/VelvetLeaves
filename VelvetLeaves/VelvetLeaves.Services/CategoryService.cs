

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
        private readonly IImageService _imageService;
        public CategoryService(VelvetLeavesDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
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
                .Where(c=> c.IsActive)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            return id;
        }

		public async Task<CategoryEditFormViewModel> GetForEditAsync(int categoryId)
		{
            var model = await _context
                .Categories
                .Where(c => c.IsActive && c.Id == categoryId)
                .Select(c => new CategoryEditFormViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageId = c.ImageId
                }).FirstAsync();

            return model;
		}
		public async Task EditAsync(CategoryEditFormViewModel model)
		{
			if(model.Image != null)
			{
                await _imageService.UpdateAsync(model.ImageId, model.Image);
			}
            
            var category = await _context
                .Categories
                .Where(c=> c.IsActive && c.Id == model.Id)
                .FirstAsync();

            category.Name = model.Name;

            await _context.SaveChangesAsync();
            
		}
        public async Task DeleteAsync(int categoryId)
        {
            var category = await _context.Categories
                .FirstAsync(c => c.Id == categoryId);

            category.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
