

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
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

        public async Task AddAsync(ProductSeriesFormViewModel model)
        {
            
            var colors = await _context.Colors.Where(c => model.DefaultColorIds.Contains(c.Id)).ToArrayAsync();
            var materials = await _context.Materials.Where(m => model.DefaultMaterialIds.Contains(m.Id)).ToArrayAsync();
            var tags = await _context.Tags.Where(t => model.DefaultTagIds.Contains(t.Id)).ToArrayAsync();


            ProductSeries productSeries = new ProductSeries()
            {
                Name = model.Name,
                DefaultName = model.DefaultName,
                DefaultDescription = model.DefaultDescription,
                DefaultPrice = model.DefaultPrice,
                SubcategoryId = model.SubcategoryId,
                DefaultColors = colors,
                DefaultMaterials = materials,
                DefaultTags = tags
            };

            await _context.ProductSeries.AddAsync(productSeries);
            await _context.SaveChangesAsync();
            
        }

        public async Task<ProductSeriesDefaultValues> GetDefaultValues(int productSeriesId)
        {
            var productSeries = await _context.ProductSeries.Select(ps => new ProductSeriesDefaultValues()
            {
                ColorIds = ps.DefaultColors.Select(c=> c.Id),
                MaterialIds = ps.DefaultMaterials.Select(c=> c.Id),
                TagIds = ps.DefaultTags.Select(c=> c.Id),
                Name = ps.DefaultName,
                Description = ps.DefaultDescription,
                Price = ps.DefaultPrice
            }).FirstAsync();

            return productSeries;
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
