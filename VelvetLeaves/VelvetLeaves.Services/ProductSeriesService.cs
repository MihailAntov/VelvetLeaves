

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
        private readonly ICategoryService _categoryService;
        
        private readonly ISubcategoryService _subcategoryService;
        private readonly ITagService _tagService;
        private readonly IMaterialService _materialService;
        private readonly IColorService _colorService;
        private readonly IGalleryService _galleryService;
        public ProductSeriesService(
            VelvetLeavesDbContext context,
            ICategoryService categoryService,
            ISubcategoryService subcategoryService,
            ITagService tagService,
            IMaterialService materialService,
            IColorService colorService,
            IGalleryService galleryService
            
            )
        {
            _context = context;
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _tagService = tagService;
            _materialService = materialService;
            _colorService = colorService;
            _galleryService = galleryService;
           

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
            var productSeries = await _context.ProductSeries
                .Where(ps=> ps.Id == productSeriesId && ps.IsActive)
                .Select(ps => new ProductSeriesDefaultValues()
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
                .Where(s => s.SubcategoryId == subcategoryId && s.IsActive)
                .Select(s=> s.Id)
                .FirstOrDefaultAsync();
            return id;
        }


        public async Task<IEnumerable<ProductSeriesSelectViewModel>> ProductSeriesBySubcategoryIdAsync(int subcategoryId)
        {
            var productSeries = await _context.ProductSeries
                .Where(ps => ps.SubcategoryId == subcategoryId && ps.IsActive)
                .Select(ps=> new ProductSeriesSelectViewModel()
                {
                    Id = ps.Id,
                    Name = ps.Name
                })
                .ToArrayAsync();

            return productSeries;
        }

		public async Task<ProductSeriesFormViewModel> GetProductSeriesByIdAsync(int productSeriesId)
		{
            
            
            ProductSeriesFormViewModel model = await _context
                .ProductSeries
                .Where(ps => ps.Id == productSeriesId && ps.IsActive)
                .Select(ps => new ProductSeriesFormViewModel()
                {
                    SubcategoryId = ps.SubcategoryId,
                    Name = ps.Name,
                    DefaultName = ps.DefaultName,
                    DefaultDescription = ps.DefaultDescription,
                    DefaultPrice = ps.DefaultPrice,
                    DefaultColorIds = ps.DefaultColors.Select(c => c.Id),
                    DefaultMaterialIds = ps.DefaultMaterials.Select(m => m.Id),
                    DefaultTagIds = ps.DefaultTags.Select(t => t.Id),
                }).FirstAsync();

            model.CategoryOptions = await _categoryService.AllCategoriesAsync();
            model.SubcategoryOptions = await _subcategoryService.AllSubcategoriesAsync();
            model.ColorOptions = await _colorService.GetAllColorsAsync();
            model.MaterialOptions = await _materialService.GetAllMaterialsAsync();
            model.TagOptions = await _tagService.GetAllTagsAsync();

            return model;
		}

        public async Task EditAsync(int productSeriesId, ProductSeriesFormViewModel model)
		{
            var productSeries = await _context
                .ProductSeries
                .Include(p=> p.DefaultColors)
                .Include(p=> p.DefaultMaterials)
                .Include(p=> p.DefaultTags)
                .FirstAsync(ps => ps.Id == productSeriesId);

            var colors = await _context.Colors.Where(c => c.IsActive &&  model.DefaultColorIds.Contains(c.Id)).ToListAsync();
            var materials = await _context.Materials.Where(m => m.IsActive && model.DefaultMaterialIds.Contains(m.Id)).ToListAsync();
            var tags = await _context.Tags.Where(t => t.IsActive && model.DefaultTagIds.Contains(t.Id)).ToListAsync();

            productSeries.Name = model.Name;
            productSeries.DefaultPrice = model.DefaultPrice;
            productSeries.DefaultDescription = model.DefaultDescription;
            productSeries.DefaultMaterials = materials;
            productSeries.DefaultColors = colors;
            productSeries.DefaultTags = tags;

            await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int productSeriesId)
		{
            var productSeries = await _context.ProductSeries
                .Include(ps=> ps.Products)
                .FirstAsync(ps => ps.Id == productSeriesId);

            productSeries.IsActive = false;

            

            foreach(var product in productSeries.Products)
            {
                product.IsActive = false;
                await _galleryService.RemoveItemFromAllGalleries(product.Id);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ProductSeriesFormViewModel> PopulateModel(ProductSeriesFormViewModel model)
        {
            
            var categories = await _categoryService.AllCategoriesAsync();
            model.CategoryId = !categories.Select(c => c.Id).Contains(model.CategoryId) ? await _categoryService.GetDefaultCategoryIdAsync() : model.CategoryId;
            model.CategoryOptions = categories;
            var subCategories = await _subcategoryService.SubcategoriesByCategoryIdAsync(model.CategoryId);
            model.SubcategoryId = !subCategories.Select(sc => sc.Id).Contains(model.SubcategoryId) ? await _subcategoryService.GetDefaultSubcategoryIdAsync(model.CategoryId) : model.SubcategoryId;
            model.SubcategoryOptions = subCategories;



            model.ColorOptions = await _colorService.GetAllColorsAsync();
            model.MaterialOptions = await _materialService.GetAllMaterialsAsync();
            model.TagOptions = await _tagService.GetAllTagsAsync();

            return model;
        }
    }
}
