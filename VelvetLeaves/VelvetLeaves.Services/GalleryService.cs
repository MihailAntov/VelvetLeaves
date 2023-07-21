

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Gallery;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Services
{
	public class GalleryService : IGalleryService
	{
		private readonly VelvetLeavesDbContext _context;
		public GalleryService(VelvetLeavesDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<GalleryViewModel>> AllGalleriesAsync()
		{
			var galleries = await _context.Galleries
				.Select(g => new GalleryViewModel()
				{
					Id = g.Id,
					Name = g.Name,
					Description = g.Description,
					ImageUrl = g.ImageUrl,
					Products = g.GalleriesProducts.Select(gp=> new ProductListViewModel()
					{
						Id = gp.Product.Id,
						Name = gp.Product.Name,
						ImageUrl = gp.Product.Images.Select(i=> i.Url).First(),
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
					ImageUrl = g.ImageUrl,
					Products = g.GalleriesProducts.Select(gp => new ProductListViewModel()
					{
						Id = gp.Product.Id,
						Name = gp.Product.Name,
						ImageUrl = gp.Product.Images.Select(i=> i.Url).First(),
						Price = gp.Product.Price
					}).ToArray()
				}).FirstOrDefaultAsync();

			return gallery;
		}
	}
}
