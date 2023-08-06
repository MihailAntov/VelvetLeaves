﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        public CategoryService(
            VelvetLeavesDbContext context,
            IImageService imageService,
            IGalleryService galleryService,
            ILogger<CategoryService> logger)
        {
            _context = context;
            _imageService = imageService;
            _galleryService = galleryService;
            _logger = logger;   
        }

        public async Task AddCategoryAsync(string categoryName, string imageId)
        {
            var category = new Category
            {
                Name = categoryName,
                ImageId = imageId
            };
            _logger.LogInformation($"Creating category with name {categoryName} and imageId {imageId}.");
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
                }).ToArrayAsync();

            _logger.LogInformation($"Returning ${categories.Length} categories.");
            return categories;
        }

		


		public async Task<int> GetDefaultCategoryIdAsync()
        {
            var id = await _context.Categories
                .Where(c=> c.IsActive)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            _logger.LogInformation($"Returning {id} as default categoryId.");
            return id;
        }

        public async Task<bool> CategoryExistsByIdAsync(int categoryId)
        {
            _logger.LogInformation($"Checking if {categoryId} is a valid categoryId");
            return await _context.Categories
                .AnyAsync(c=> c.Id == categoryId && c.IsActive);
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
                }).FirstOrDefaultAsync();
            

            if(model == null)
            {
                _logger.LogWarning($"Category with id {categoryId} for edit not found.");
                throw new ArgumentException();
            }
            _logger.LogInformation($"Returning category {model.Name} for edit. ");
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
            _logger.LogInformation($"Category {model.Id} updated. ");
            await _context.SaveChangesAsync();
            
		}
        public async Task DeleteAsync(int categoryId)
        {
            if(!await CategoryExistsByIdAsync(categoryId))
            {
                _logger.LogWarning($"Category with id {categoryId} for delete not found. ");
                throw new ArgumentException();
            }


            
            var category = await _context.Categories
                .Include(c=> c.Subcategories)
                .ThenInclude(sc=> sc.ProductSeries)
                .ThenInclude(sc=>sc.Products)
                .FirstAsync(c => c.Id == categoryId);

            category.IsActive = false;
            _logger.LogInformation($"Removing category with id {categoryId}");

            foreach(var subcategory in category.Subcategories)
            {
                _logger.LogInformation($"Removing subcategory {subcategory.Id}");
                subcategory.IsActive = false;
                foreach(var series in subcategory.ProductSeries)
                {
                    _logger.LogInformation($"Removing productSeries {series.Id}");
                    series.IsActive = false;
                    foreach(var product in series.Products)
                    {
                        _logger.LogInformation($"Removing product {product.Id}");
                        product.IsActive = false;
                        
                        await _galleryService.RemoveItemFromAllGalleries(product.Id);

                    }
                }
            }

            await _context.SaveChangesAsync();
        }




    }
}
