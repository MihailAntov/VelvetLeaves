

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.ProductSeries;
using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly VelvetLeavesDbContext _context;
        public CategoryService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(string categoryName, string imageId)
        {
            var category = new Category
            {
                Name = categoryName,
                ImageId = imageId
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryListViewModel>> AllCategoriesAsync()
        {
            var categories = await _context
                .Categories
                .Select(c => new CategoryListViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    //ImageUrl = c.ImageUrl
                }).ToArrayAsync();

            return categories;
        }

        public async Task<IEnumerable<CategoryListViewModel>> GetProductTreeAsync()
        {
            var categories = await _context
                .Categories
                .Select(c => new CategoryListViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Anchor = c.Name.Replace(" ", ""),
                    ImageId = c.ImageId,
                    Subcategories = c.Subcategories
                    .Select(sc => new SubcategoryListViewModel()
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        Anchor = sc.Name.Replace(" ", ""),
                        ImageId = sc.ImageId,
                        ProductSeries = sc.ProductSeries
                        .Select(ps => new ProductSeriesListViewModel()
                        {
                            Id = ps.Id,
                            Name = ps.Name,
                            Anchor = ps.Name.Replace(" ", ""),
                            Products = ps.Products
                            .Select(p => new ProductListViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                ImageId = p.Images.First().Id
                            })

                        })
                    })

                }).ToArrayAsync();

            return categories;
        }
    }
}
