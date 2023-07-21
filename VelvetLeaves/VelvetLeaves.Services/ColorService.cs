
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services
{
    public class ColorService : IColorService
    {
        private readonly VelvetLeavesDbContext _context;
        public ColorService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ColorSelectViewModel>> GetColorOptionsAsync(int? categoryId, int? subcategoryId)
        {
            var products = _context.Products.AsQueryable();
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.Subcategory.CategoryId == categoryId);
            }

            if (subcategoryId.HasValue)
            {
                products = products.Where(p => p.SubcategoryId == subcategoryId);
            }

            var colors = await products.SelectMany(p => p.Colors).Distinct()
                .Select(c => new ColorSelectViewModel()
                {
                    ColorValue = c.ColorValue,
                    Id = c.Id
                })
                .ToArrayAsync();
            return colors;
        }
    }
}
