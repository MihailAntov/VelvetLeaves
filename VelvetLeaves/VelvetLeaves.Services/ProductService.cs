

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Service.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services
{
    public class ProductService : IProductService
    {
        private readonly VelvetLeavesDbContext _context;
        public ProductService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            var result = await _context.Products.AnyAsync(p => p.Id == id);
            return result;
        }

        public async Task<ProductDetailsViewModel> DetailsByIdAsync(int id)
        {
            ProductDetailsViewModel model = await _context
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Images = p.Images.Select(i=> i.Id).ToArray(),
                    Materials = p.Materials.Select(m=> m.Name).ToArray(),
                    Tags = p.Tags.Select(t=> t.Name).ToArray(),
                    ProductSeries = p.ProductSeries
                                    .Products
                                    .Where(lp => lp.Id != id)
                                    .Select(lp=> new ProductListViewModel()
                                    {
                                        Id = lp.Id, 
                                        Name = lp.Name,
                                        ImageId = lp.Images.Select(i=> i.Id).First(),
                                        Price =lp.Price
                                    }).ToArray()
                                    
                }).FirstAsync();

            return model;
        }

        public async Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model)
		{
            IQueryable<Product> products = _context.Products.AsQueryable();

			if (model.CategoryId.HasValue)
			{
                products = products.Where(p => p.Subcategory.CategoryId == model.CategoryId);
			}

			if (model.SubCategoryId.HasValue)
			{
                products = products.Where(p => p.SubcategoryId == model.SubCategoryId);
			}

            if(model.SearchString != null)
			{
                products = products.Where(p => p.Name.Contains(model.SearchString.ToLower()));
			}

			if (model.ColorIds.Any())
			{
                products = products.Where(p => p.Colors.Select(c => c.Id).Any(id=> model.ColorIds.Contains(id)));
			}

            if (model.Materials.Any())
            {
                products = products.Where(p => p.Materials.Any(m=> model.Materials.Contains(m.Name)));
            }

            if (model.Tags.Any())
            {
                products = products.Where(p => p.Tags.Any(t => model.Tags.Contains(t.Name)));
            }

            var productsFiltered = await products
                .Skip(model.CurrentPage - 1)
                .Take(model.ProductsPerPage)
                .Select(p => new ProductListViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageId = p.Images.Select(i=>i.Id).First(),
                    Price = p.Price
                }).ToArrayAsync();

            return new ProductsFilteredAndPagedServiceModel()
            {
                Products = productsFiltered,
                TotalProductCount = products.Count()
            };


		}
	}
}
