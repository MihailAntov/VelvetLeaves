

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Material;

namespace VelvetLeaves.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly VelvetLeavesDbContext _context;
        public MaterialService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaterialListViewModel>> GetMaterialOptionsAsync(int? categoryId, int? subcategoryId)
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

            var materials = await products.SelectMany(p => p.Materials.Select(m => new MaterialListViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            })).Distinct().ToArrayAsync();
            return materials;
        }
    }
}
