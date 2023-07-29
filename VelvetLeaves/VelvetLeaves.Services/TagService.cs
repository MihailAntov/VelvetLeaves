

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
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

        public async Task AddAsync(TagFormViewModel model)
        {
            Tag tag = new Tag()
            {
                Name = model.Name
            };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

		public async Task DeleteAsync(int tagId)
		{
            var tag = await _context.Tags
                .FirstAsync(t => t.Id == tagId);

            tag.IsActive = false;
            await _context.SaveChangesAsync();
        }

		public async Task<IEnumerable<TagListViewModel>> GetAllTagsAsync()
        {
            var tags = await _context.Tags
                .Where(t => t.IsActive)
                .Select(t => new TagListViewModel()
                {
                    Name = t.Name,
                    Id = t.Id
                })
                .ToArrayAsync();
            return tags;
        }

        public async Task<IEnumerable<TagListViewModel>> GetTagOptionsAsync(int? categoryId, int? subcategoryId)
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

            var tags = await products.SelectMany(p => p.Tags.Select(t => new TagListViewModel()
            {
                Id = t.Id,
                Name  = t.Name
            })).Distinct().ToArrayAsync();
            return tags;
        }

        
    }
}
