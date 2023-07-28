

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Gallery;
using VelvetLeaves.Data.Models;

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
						ImageId = gp.Product.Images.Select(i=> i.Id).First(),
						Price = gp.Product.Price
					}).ToArray()
				}).FirstOrDefaultAsync();

			return gallery;
		}
	}
}
