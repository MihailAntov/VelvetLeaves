

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly VelvetLeavesDbContext _context;
        public MaterialService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetMaterialOptionsAsync(int? categoryId, int? subcategoryId)
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

            var materials = await products.SelectMany(p => p.Materials.Select(m => m.Name)).Distinct().ToArrayAsync();
            return materials;
        }
    }
}
