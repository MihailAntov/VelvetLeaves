

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Service.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Services
{
    public class ProductService : IProductService
    {
        private readonly VelvetLeavesDbContext _context;
        public ProductService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductViewModel>> AllProductsByCategoryAsync(int categoryId)
        {
            var products = await _context.Products
                .Where(p => p.Subcategory.CategoryId == categoryId)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    PictureUrl = p.ImageUrl
                }).ToArrayAsync();

            return products;
        }

        public async Task<IEnumerable<ProductViewModel>> AllProductsBySubCategoryAsync(int subcategoryId)
        {
            var products = await _context.Products
                .Where(p => p.Subcategory.Id == subcategoryId)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    PictureUrl = p.ImageUrl
                }).ToArrayAsync();

            return products;
        }

		public Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model)
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
                products = products.Where(p => p.Name.Contains(model.SearchString));
			}
		}
	}
}
