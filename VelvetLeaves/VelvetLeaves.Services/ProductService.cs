

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
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

        public async Task<IEnumerable<ProductViewModel>> AllProductsByCategory(int categoryId)
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
        }
    }
}
