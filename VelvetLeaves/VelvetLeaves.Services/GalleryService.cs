

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Gallery;
using VelvetLeaves.Data.Models;
using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.Services
{
    public class GalleryService : IGalleryService
	{
		private readonly VelvetLeavesDbContext _context;
		public GalleryService(VelvetLeavesDbContext context)
		{
			_context = context;
		}

        public async Task AddAsync(GalleryFormViewModel model)
        {
			Gallery gallery = new Gallery()
			{
				Name = model.Name,
				Description = model.Description,
				ImageId = model.ImageId!
			};
			await _context.Galleries.AddAsync(gallery);
			await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GalleryViewModel>> AllGalleriesAsync()
		{
			var galleries = await _context.Galleries
				.Select(g => new GalleryViewModel()
				{
					Id = g.Id,
					Name = g.Name,
					Description = g.Description,
					ImageId = g.ImageId,
					Products = g.GalleriesProducts.Select(gp=> new ProductListViewModel()
					{
						Id = gp.Product.Id,
						Name = gp.Product.Name,
						ImageId = gp.Product.Images.Select(i=> i.Id).First(),
						Price = gp.Product.Price
					}).ToArray()
				}).ToArrayAsync();

			return galleries;
		}


        public async Task<GalleryViewModel?> GetGalleryByIdAsync(int id)
		{
			var gallery = await _context.Galleries.Where(g => g.Id == id)
				.Select(g => new GalleryViewModel()
				{
					Id = g.Id,
					Name = g.Name,
					Description = g.Description,
					ImageId = g.ImageId,
					Products = g.GalleriesProducts.Select(gp => new ProductListViewModel()
					{
						Id = gp.Product.Id,
						Name = gp.Product.Name,
						Position = gp.Position,
						ImageId = gp.Product.Images.Select(i=> i.Id).First(),
						Price = gp.Product.Price
					}).OrderBy(p=> p.Position)
					.ToArray()
				}).FirstOrDefaultAsync();

			return gallery;
		}

        public async Task Delete(int productId, int galleryId)
        {
            var gp = await _context.GalleriesProducts.FirstAsync(gp=> gp.ProductId == productId && gp.GalleryId == galleryId);
			_context.GalleriesProducts.Remove(gp);
			await _context.SaveChangesAsync();
        }
        public async Task MoveLeft(int productId, int galleryId)
        {

			var products = await _context.GalleriesProducts
				.Include(gp => gp.Product)
				.Where(gp => gp.GalleryId == galleryId)
				.ToArrayAsync();

			var product = products.First(p => p.ProductId == productId);
			var previousProduct = products.FirstOrDefault(p => p.Position == product.Position - 1);
			if(previousProduct == null)
            {
				return;
            }

			product.Position--;
			previousProduct.Position++;
			await _context.SaveChangesAsync();
		}

        public async Task MoveRight(int productId, int galleryId)
        {
			var products = await _context.GalleriesProducts
				.Include(gp => gp.Product)
				.Where(gp => gp.GalleryId == galleryId)
				.ToArrayAsync();

			var product = products.First(p => p.ProductId == productId);
			var previousProduct = products.FirstOrDefault(p => p.Position == product.Position + 1);
			if (previousProduct == null)
			{
				return;
			}

			product.Position++;
			previousProduct.Position--;
			await _context.SaveChangesAsync();
		}

        public async Task<bool> ProductInGallery(int productId, int galleryId)
        {
			
			if(!await _context.GalleriesProducts.AnyAsync(gp=> gp.ProductId == productId && gp.GalleryId == galleryId))
            {
				return false;
            }

			return true;
			
        }

        public async Task<AddToGalleryViewModel> GetItemsToAddAsync(int galleryId)
        {
			var model = new AddToGalleryViewModel();
			var existingIdsInGallery = _context
				.GalleriesProducts
				.Where(gp => gp.GalleryId == galleryId)
				.Select(gp => gp.ProductId);
			model.GalleryId = galleryId;
			model.GalleryName = await  _context.Galleries.Select(g => g.Name).FirstAsync();
			model.Categories = await _context
				.Categories
				.Select(c => new CategoryListViewModel()
				{
					Id = c.Id,
					Name = c.Name,
					Subcategories = c.Subcategories
					.Select(sc => new SubCategoryListViewModel()
					{
						Id = sc.Id,
						Name = sc.Name,
						Products = sc.Products
						.Where(p => !existingIdsInGallery.Contains(p.Id))
						.Select(p => new ProductListViewModel()
						{
							Name = p.Name,
							Id = p.Id,
							ImageId = p.Images.First().Id,

						})
					})
				}).ToArrayAsync();

			return model;
        }
    }
}
