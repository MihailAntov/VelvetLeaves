

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.Services
{
    public class TagService : ITagService
    {
        private readonly VelvetLeavesDbContext _context;
        public TagService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagListViewModel>> GetTagOptionsAsync(int? categoryId, int? subcategoryId)
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

            var tags = await products.SelectMany(p => p.Tags.Select(t => new TagListViewModel()
            {
                Id = t.Id,
                Name  = t.Name
            })).Distinct().ToArrayAsync();
            return tags;
        }

        
    }
}
