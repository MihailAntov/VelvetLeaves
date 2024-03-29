﻿

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
		private readonly ICategoryService _categoryService;
		private readonly IImageService _imageService;
		private readonly IGalleryService _galleryService;
        public SubcategoryService(
			VelvetLeavesDbContext context,
			ICategoryService categoryService,
			IImageService imageService,
			IGalleryService galleryService)
		{
			_context = context;
			_categoryService = categoryService;
			_imageService = imageService;
			_galleryService = galleryService;
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
				.Where(sc => sc.IsActive)
				.Select(sc => new SubcategorySelectViewModel()
				{
					Id = sc.Id,
					Name = sc.Name
				}).ToArrayAsync();

			return subcategories;
        }

		public  async Task DeleteAsync(int subcategoryId)
		{
			if(!await ExistsByIdAsync(subcategoryId))
            {
				throw new InvalidOperationException();
            }
			
			var subcategory = await _context.Subcategories
				.Include(sc=> sc.ProductSeries)
				.ThenInclude(ps=> ps.Products)
				.FirstAsync(sc => sc.Id == subcategoryId);

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
			await _context.SaveChangesAsync();
		}

		public async Task EditAsync(SubcategoryEditFormViewModel model)
		{
			if (!await ExistsByIdAsync(model.Id))
			{
				throw new InvalidOperationException();
			}

			if (model.Image != null)
			{
				await _imageService.UpdateAsync(model.ImageId, model.Image);
			}

			var subcategory = await _context.Subcategories
				.Where(sc => sc.Id == model.Id && sc.IsActive)
				.FirstAsync();

			subcategory.Name = model.Name;
			subcategory.CategoryId = model.CategoryId;
			await _context.SaveChangesAsync();
		}

        public async Task<bool> ExistsByIdAsync(int subcategoryId)
        {
			return await _context.Subcategories.AnyAsync(sc => sc.IsActive && sc.Id == subcategoryId);
        }

        public async Task<int> GetDefaultSubcategoryIdAsync(int categoryId)
        {
			var id = await _context.Subcategories
				.Where(sc => sc.CategoryId == categoryId && sc.IsActive)
				.Select(sc => sc.Id)
				.FirstOrDefaultAsync();

			return id;
        }

		public async Task<SubcategoryEditFormViewModel> GetForEditAsync(int subcategoryId)
		{
			SubcategoryEditFormViewModel model = await _context
				.Subcategories
				.Where(sc => sc.Id == subcategoryId && sc.IsActive)
				.Select(sc => new SubcategoryEditFormViewModel()
				{
					Id = sc.Id,
					Name = sc.Name,
					CategoryId = sc.CategoryId,
					ImageId = sc.ImageId
				}).FirstAsync();

			model.CategoryOptions = await _categoryService.AllCategoriesAsync();

			return model;
		}

        public async Task<SubcategoryFormViewModel> PopulateModel(SubcategoryFormViewModel model)
        {
			var categories = await _categoryService.AllCategoriesAsync();
			model.CategoryId = !categories.Select(c => c.Id).Contains(model.CategoryId) ? await _categoryService.GetDefaultCategoryIdAsync() : model.CategoryId;
			model.CategoryOptions = categories;

			return model;
		}

        public async Task<IEnumerable<SubcategorySelectViewModel>> SubcategoriesByCategoryIdAsync(int categoryId)
        {
			var subcategories = await _context.Subcategories
				.Where(s=> s.CategoryId == categoryId && s.IsActive)
				.Select(sc => new SubcategorySelectViewModel()
				{
					Id = sc.Id,
					Name = sc.Name
				}).ToArrayAsync();

			return subcategories;
		}
    }
}
