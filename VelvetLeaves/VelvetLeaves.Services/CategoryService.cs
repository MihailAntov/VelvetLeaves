

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
        private readonly IGalleryService _galleryService;
        public CategoryService(VelvetLeavesDbContext context, IImageService imageService, IGalleryService galleryService)
        {
            _context = context;
            _imageService = imageService;
            _galleryService = galleryService;
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

        public async Task<bool> CategoryExistsByIdAsync(int categoryId)
        {
            return await _context.Categories
                .AnyAsync(c=> c.Id == categoryId);
        }

		public async Task<CategoryEditFormViewModel> GetForEditAsync(int categoryId)
		{
            if(!await CategoryExistsByIdAsync(categoryId))
            {
                throw new ArgumentException();
            }
            
            var model = await _context
                .Categories
                .Where(c => c.IsActive && c.Id == categoryId)
                .Select(c => new CategoryEditFormViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageId = c.ImageId
                }).FirstOrDefaultAsync();

            if(model == null)
            {
                throw new ArgumentException();
            }

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
            if(!await CategoryExistsByIdAsync(categoryId))
            {
                throw new ArgumentException();
            }
            
            var category = await _context.Categories
                .Include(c=> c.Subcategories)
                .ThenInclude(sc=> sc.ProductSeries)
                .ThenInclude(sc=>sc.Products)
                .FirstAsync(c => c.Id == categoryId);

            category.IsActive = false;
            

            foreach(var subcategory in category.Subcategories)
            {
                subcategory.IsActive = false;
                foreach(var series in subcategory.ProductSeries)
                {
                    series.IsActive = false;
                    foreach(var product in series.Products)
                    {
                        product.IsActive = false;
                        await _galleryService.RemoveItemFromAllGalleries(product.Id);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }




    }
}
