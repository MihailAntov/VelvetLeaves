
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
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

        public async Task AddAsync(ColorFormViewModel model)
        {
            Color color = new Color()
            {
                Name = model.Name,
                ColorValue = model.Color
            };

            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
        }

		public async Task DeleteAsync(int colorId)
		{
            if(!await ExistsByIdAsync(colorId))
            {
                throw new InvalidOperationException();
            }
            
            var color = await _context.Colors
                .FirstAsync(c => c.Id == colorId);

            color.IsActive = false;
            await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ColorSelectViewModel>> GetAllColorsAsync()
        {
            var colors = await _context.Colors
                .Where(c => c.IsActive)
                .Select(c => new ColorSelectViewModel()
                {
                    ColorValue = c.ColorValue,
                    Id = c.Id
                })
                .ToArrayAsync();
            return colors;
        }

        public async Task<IEnumerable<ColorSelectViewModel>> GetColorOptionsAsync(int? categoryId, int? subcategoryId)
        {
            var products = _context.Products.AsQueryable();
            if (categoryId.HasValue && categoryId != 0)
            {
                products = products.Where(p => p.Subcategory.CategoryId == categoryId);
            }

            if (subcategoryId.HasValue & subcategoryId != 0)
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

        public async Task<bool> ExistsByIdAsync(int colorId)
        {
            return await _context.Colors.AnyAsync(c => c.IsActive && c.Id == colorId);
        }
    }
}
