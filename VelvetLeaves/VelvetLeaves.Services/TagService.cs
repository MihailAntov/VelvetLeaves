

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class TagService : ITagService
    {
        private readonly VelvetLeavesDbContext _context;
        public TagService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetTagOptionsAsync(int? categoryId, int? subcategoryId)
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

            var tags = await products.SelectMany(p => p.Tags.Select(m => m.Name)).Distinct().ToArrayAsync();
            return tags;
        }
    }
}
