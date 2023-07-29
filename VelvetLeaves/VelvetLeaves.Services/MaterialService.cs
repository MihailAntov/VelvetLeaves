

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
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

        public async Task AddAsync(MaterialFormViewModel model)
        {
            Material material = new Material()
            {
                Name = model.Name
            };
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

		public async Task DeleteAsync(int materialId)
		{
            var material = await _context
                .Materials
                .Where(m => m.Id == materialId)
                .FirstAsync();

            material.IsActive = false;
            await _context.SaveChangesAsync();
        }

		public async Task<IEnumerable<MaterialListViewModel>> GetAllMaterialsAsync()
        {
            var materials = await _context.Materials
                .Where(m => m.IsActive)
                .Select(m => new MaterialListViewModel()
                {
                    Name = m.Name,
                    Id = m.Id
                }).ToArrayAsync();

            return materials;
        }

        public async Task<IEnumerable<MaterialListViewModel>> GetMaterialOptionsAsync(int? categoryId, int? subcategoryId)
        {
            var products = _context.Products.Where(p => p.IsActive).AsQueryable();
            if (categoryId.HasValue && categoryId > 0)
            {
                products = products.Where(p => p.Subcategory.CategoryId == categoryId);
            }

            if (subcategoryId.HasValue && subcategoryId > 0)
            {
                products = products.Where(p => p.SubcategoryId == subcategoryId);
            }

            var materials = await products.SelectMany(p => p.Materials.Where(m => m.IsActive).Select(m => new MaterialListViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            })).Distinct().ToArrayAsync();
            return materials;
        }
    }
}
