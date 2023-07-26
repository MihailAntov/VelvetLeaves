

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.Services
{
    public class ProductSeriesService : IProductSeriesService
    {
        private readonly VelvetLeavesDbContext _context;
        public ProductSeriesService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetDefaultProductSeriesIdAsync(int subcategoryId)
        {
            var id = await _context.ProductSeries
                .Where(s => s.SubcategoryId == subcategoryId)
                .Select(s=> s.Id)
                .FirstOrDefaultAsync();
            return id;
        }

        public async Task<IEnumerable<ProductSeriesSelectViewModel>> ProductSeriesBySubcategoryIdAsync(int subcategoryId)
        {
            var productSeries = await _context.ProductSeries
                .Where(ps => ps.SubcategoryId == subcategoryId)
                .Select(ps=> new ProductSeriesSelectViewModel()
                {
                    Id = ps.Id,
                    Name = ps.Name
                })
                .ToArrayAsync();

            return productSeries;
        }
    }
}
