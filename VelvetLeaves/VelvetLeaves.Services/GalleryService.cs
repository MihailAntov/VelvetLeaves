

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Gallery;
using VelvetLeaves.Data.Models;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Subcategory;

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
				.Where(g => g.IsActive)
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
			var gallery = await _context.Galleries.Where(g => g.Id == id && g.IsActive)
				.Select(g => new GalleryViewModel()
				{
					Id = g.Id,
					Name = g.Name,
					Description = g.Description,
					ImageId = g.ImageId,
					Products = g.GalleriesProducts
					.Where(gp => gp.Product.IsActive)
					.Select(gp => new ProductListViewModel()
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

        public async Task DeleteItem(int productId, int galleryId)
        {
            var gp = await _context.GalleriesProducts.FirstAsync(gp=> gp.ProductId == productId && gp.GalleryId == galleryId);
			var remainingItems = _context.GalleriesProducts.Where(ri => ri.Position > gp.Position && ri.GalleryId == galleryId);
			if (remainingItems.Any())
			{
				foreach(var item in remainingItems)
				{
					item.Position--;
				}
			}
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
				.Where(c=> c.IsActive)
				.Select(c => new CategoryListViewModel()
				{
					Id = c.Id,
					Name = c.Name,
					Subcategories = c.Subcategories
					.Where(sc => sc.IsActive)
					.Select(sc => new SubcategoryListViewModel()
					{
						Id = sc.Id,
						Name = sc.Name,
						Products = sc.Products
						.Where(p => !existingIdsInGallery.Contains(p.Id))
						.Where(p => p.IsActive)
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

        public async Task AddItemsToGalleryAsync(int galleryId, IEnumerable<int> items)
        {
			
			int currentLength = await _context.GalleriesProducts
				.Where(gp => gp.GalleryId == galleryId)
				.CountAsync();

			ICollection<GalleryProduct> galleriesProducts = new List<GalleryProduct>();

			foreach(var item in items)
			{
				galleriesProducts.Add(new GalleryProduct
				{
					GalleryId = galleryId,
					ProductId = item,
					Position = ++currentLength
				});
			}

			await _context.GalleriesProducts.AddRangeAsync(galleriesProducts);
			await _context.SaveChangesAsync();
        }

		public async Task<GalleryEditFormViewModel> GetGalleryEditFormAsync(int galleryId)
		{
			GalleryEditFormViewModel model = await _context.Galleries
				.Where(g => g.Id == galleryId && g.IsActive)
				.Select(g => new GalleryEditFormViewModel()
				{
					Id = galleryId,
					Name = g.Name,
					Description = g.Description,
					ImageId = g.ImageId
				}).FirstAsync();

			return model;
		}

		public async Task EditAsync(GalleryEditFormViewModel model)
		{
			var gallery = await _context.Galleries
				.Where(g => g.IsActive)
				.FirstAsync(g => g.Id == model.Id);
			gallery.Name = model.Name;
			gallery.Description = model.Description;
			gallery.ImageId = model.ImageId!;

			await _context.SaveChangesAsync();
		}

		
		public async Task DeleteAsync(int galleryId)
		{
			var gallery = await _context
				.Galleries
				.Where(g => g.Id == galleryId)
				.FirstAsync();

			gallery.IsActive = false;
			await _context.SaveChangesAsync();
		}

        public async Task RemoveItemFromAllGalleries(int productId)
        {
			var galleries = await _context.GalleriesProducts
				.Where(gp => gp.ProductId == productId).ToArrayAsync();

			foreach(var gallery in galleries)
            {
				await DeleteItem(gallery.ProductId, gallery.GalleryId);
            }

			
        }
    }
}
