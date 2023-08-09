

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Service.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Subcategory;
using VelvetLeaves.ViewModels.ProductSeries;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.Tag;
using Microsoft.Extensions.Logging;

namespace VelvetLeaves.Services
{
    public class ProductService : IProductService
    {
        private readonly VelvetLeavesDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IProductSeriesService _productSeriesService;
        private readonly ITagService _tagService;
        private readonly IMaterialService _materialService;
        private readonly IColorService _colorService;
        private readonly IImageService _imageService;
        private readonly IGalleryService _galleryService;
        private readonly ILogger _logger;
        public ProductService(
            VelvetLeavesDbContext context,
            ICategoryService categoryService,
            ISubcategoryService subcategoryService,
            IProductSeriesService productSeriesService,
            ITagService tagService,
            IMaterialService materialService,
            IColorService colorService,
            IImageService imageService,
            IGalleryService galleryService,
            ILogger<ProductService> logger
            )
        {
            _context = context;
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _materialService = materialService;
            _tagService = tagService;
            _productSeriesService = productSeriesService;
            _colorService = colorService;
            _imageService = imageService;
            _galleryService = galleryService;
            _logger = logger;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            
            var result = await _context.Products.AnyAsync(p => p.Id == id && p.IsActive);
            return result;
        }

        public async Task<ProductDetailsViewModel> DetailsByIdAsync(int id)
        {
            if(!await ExistsByIdAsync(id))
            {
                _logger.LogError($"Product with id {id} not found.");
                throw new InvalidOperationException();
            }
            
            ProductDetailsViewModel model = await _context
                .Products
                .Where(p => p.Id == id && p.IsActive)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    IsAvailable = p.IsAvailable,
                    Images = p.Images.Select(i=> i.Id).ToArray(),
                    Materials = p.Materials
                        .Select(m=> new MaterialListViewModel()
                        {
                            Name = m.Name,
                            Id = m.Id
                        }).ToArray(),
                    Tags = p.Tags
                        .Select(t=> new TagListViewModel()
                        {
                            Name = t.Name,
                            Id = t.Id
                        }).ToArray(),
                    ProductSeries = p.ProductSeries
                                    .Products
                                    .Where(lp => lp.Id != id && lp.IsActive)
                                    .Select(lp=> new ProductListViewModel()
                                    {
                                        Id = lp.Id, 
                                        Name = lp.Name,
                                        ImageId = lp.Images.Select(i=> i.Id).First(),
                                        Price =lp.Price,
                                        Colors = lp.Colors.Select(c=>c.ColorValue).ToHashSet()
                                    })
                                    
                }).FirstAsync();


            return model;
        }

        public async Task<ProductsFilteredAndPagedServiceModel> ProductsFilteredAndPagedAsync(ProductsQueryModel model)
		{
            IQueryable<Product> products = _context.Products.Where(p => p.IsActive).AsQueryable();

			if (model.CategoryId.HasValue)
			{
                products = products.Where(p => p.Subcategory.CategoryId == model.CategoryId);
			}

			if (model.SubCategoryId.HasValue)
			{
                products = products.Where(p => p.SubcategoryId == model.SubCategoryId);
			}

            if(model.SearchString != null)
			{
                products = products.Where(p => p.Name.ToLower().Contains(model.SearchString.ToLower()));
			}

			if (model.ColorIds.Any())
			{
                products = products.Where(p => p.Colors.Select(c => c.Id).Any(id=> model.ColorIds.Contains(id)));
			}

            if (model.Materials.Any())
            {
                products = products.Where(p => p.Materials.Any(m=> model.Materials.Contains(m.Id)));
            }

            if (model.Tags.Any())
            {
                products = products.Where(p => p.Tags.Any(t => model.Tags.Contains(t.Name)));
            }

            int maxPages = (int)Math.Ceiling((double)products.Count() / (double)model.ProductsPerPage);

            var productsFiltered = await products
                .Skip((model.CurrentPage - 1) * model.ProductsPerPage)
                .Take(model.ProductsPerPage)
                .Select(p => new ProductListViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageId = p.Images.Select(i=>i.Id).First(),
                    Price = p.Price
                }).ToArrayAsync();

            _logger.LogInformation($"Returning {products.Count()} total products.");
            return new ProductsFilteredAndPagedServiceModel()
            {
                Products = productsFiltered,
                TotalProductCount = products.Count()
            };


		}

        public async Task<ProductTreeViewModel> GetProductTreeAsync(int? categoryId, int? subcategoryId, int? productSeriesId)
        {
            ProductTreeViewModel model = new ProductTreeViewModel()
            {
                CategoryId = categoryId.HasValue ? categoryId.Value : null,
                SubcategoryId = subcategoryId.HasValue ? subcategoryId.Value : null,
                ProductSeriesId = productSeriesId.HasValue ? productSeriesId.Value : null,
            };

            model.Products = await _context
                .Categories
                .Where(c => c.IsActive)
                .Select(c => new CategoryListViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Anchor = c.Name.Replace(" ", ""),
                    ImageId = c.ImageId,
                    Subcategories = c.Subcategories
                    .Where(sc => sc.IsActive)
                    .Select(sc => new SubcategoryListViewModel()
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        Anchor = sc.Name.Replace(" ", ""),
                        ImageId = sc.ImageId,
                        ProductSeries = sc.ProductSeries
                        .Where(ps => ps.IsActive)
                        .Select(ps => new ProductSeriesListViewModel()
                        {
                            Id = ps.Id,
                            Name = ps.Name,
                            Anchor = ps.Name.Replace(" ", ""),
                            Products = ps.Products
                            .Where(p => p.IsActive)
                            .Select(p => new ProductListViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                ImageId = p.Images.First().Id
                            })

                        })
                    })

                }).ToArrayAsync();
            
            return model;
        }

        public async Task AddAsync(ProductFormViewModel model)
        {
            var series = await _context.ProductSeries.FirstAsync(ps=> ps.Id == model.ProductSeriesId);
            if(series.SubcategoryId != model.SubcategoryId)
            {
                throw new InvalidOperationException();
            }

            var subcategory = await _context.Subcategories.FirstAsync(sc => sc.Id == model.SubcategoryId);
            if (subcategory.CategoryId != model.CategoryId)
            {
                throw new InvalidOperationException();
            }

            var category = await _context.Categories.FirstAsync(c=> c.Id == model.CategoryId);


            Product product = new Product()
            {
                Name = model.Name,
                SubcategoryId = model.SubcategoryId,
                ProductSeriesId = model.ProductSeriesId,
                Description = model.Description,
                Price = model.Price,
                Images = model.ImageIds!.Select(i => new Image()
                {
                    Id = i
                }).ToArray(),
                Colors = model.ColorIds.Select(cId =>  _context.Colors.First(c=> c.Id == cId)).ToArray(),
                Materials = model.MaterialIds.Select(mId =>  _context.Materials.First(m=> m.Id == mId)).ToArray(),
                Tags = model.TagIds.Select(tId =>  _context.Tags.First(t=> t.Id == tId)).ToArray(),
                
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            
        }

        public async Task<ProductFormViewModel> GetFormForAddAsync(int categoryId, int subcategoryId, int productSeriesId)
        {
            var model = new ProductFormViewModel();
            var categories = await _categoryService.AllCategoriesAsync();
            model.CategoryId = categories.Select(c => c.Id).Contains(categoryId) ? categoryId : await _categoryService.GetDefaultCategoryIdAsync();
            model.CategoryOptions = categories;
            var subCategories = await _subcategoryService.SubcategoriesByCategoryIdAsync(model.CategoryId);
            model.SubcategoryId = subCategories.Select(c => c.Id).Contains(subcategoryId) ? subcategoryId : await _subcategoryService.GetDefaultSubcategoryIdAsync(model.CategoryId);
            model.SubcategoryOptions = subCategories;
            var productSeries = await _productSeriesService.ProductSeriesBySubcategoryIdAsync(model.SubcategoryId);
            model.ProductSeriesId = productSeries.Select(ps => ps.Id).Contains(productSeriesId) ? productSeriesId : await _productSeriesService.GetDefaultProductSeriesIdAsync(model.SubcategoryId);
            model.ProductSeriesOptions = productSeries;

            model.ColorOptions = await _colorService.GetAllColorsAsync();
            model.MaterialOptions = await _materialService.GetAllMaterialsAsync();
            model.TagOptions = await _tagService.GetAllTagsAsync();



            ProductSeriesDefaultValues defaultValues = await _productSeriesService.GetDefaultValues(model.ProductSeriesId);
            model.DefaultTagIds = defaultValues.TagIds;
            model.DefaultColorIds = defaultValues.ColorIds;
            model.DefaultMaterialIds = defaultValues.MaterialIds;
            model.Name = defaultValues.Name ?? String.Empty;
            model.Price = defaultValues.Price ?? 0.00M;
            model.Description = defaultValues.Description ?? String.Empty;

            return model;
        }

        public async Task<ProductEditFormViewModel> GetFormForEditAsync(int productId)
        {
            if(!await ExistsByIdAsync(productId))
            {
                throw new InvalidOperationException();
            }

            var model = await _context.Products
                .Where(p => p.Id == productId && p.IsActive)
                .Select(p => new ProductEditFormViewModel()
                {
                    Id = p.Id,
                    CategoryId = p.Subcategory.CategoryId,
                    SubcategoryId = p.SubcategoryId,
                    ProductSeriesId = p.ProductSeriesId,
                    Name = p.Name,
                    ColorIds = p.Colors.Select(c => c.Id),
                    TagIds = p.Tags.Select(t => t.Id),
                    MaterialIds = p.Materials.Select(m => m.Id),
                    Description = p.Description,
                    ImageIds = p.Images.Select(i => i.Id).ToList(),
                    Price = p.Price,
                    IsAvailable = p.IsAvailable
                }).FirstAsync();

            model.ColorOptions = await _colorService.GetAllColorsAsync();
            model.TagOptions = await _tagService.GetAllTagsAsync();
            model.MaterialOptions = await _materialService.GetAllMaterialsAsync();

            return model;
        }

		public async Task UpdateAsync(ProductEditFormViewModel model)
		{
            if(!await ExistsByIdAsync(model.Id))
            {
                throw new InvalidOperationException();
            }
            
            model.ImageIds = model.StartingImageIds!.ToList();
			if (model.Images!= null)
			{

                var ids = await _imageService.CreateRangeAsync(model.Images);
                foreach(var id in ids)
				{
                    if(id != null)
					{
                        model.ImageIds.Add(id);
					}
				}
			}
            //if(model.StartingImageIds != null && model.KeptImageIds != null)
            
                var imgsToDelete = model.StartingImageIds.Where(i => !model.KeptImageIds.Contains(i));
                foreach(var img in imgsToDelete)
				{
                    await _imageService.RemoveAsync(img);
                    model.ImageIds.Remove(img);
				}
			

            var product = await _context.Products
                .Where(p => p.IsActive)
                .Include(p=>p.Images)
                .Include(p=>p.Colors)
                .Include(p=>p.Materials)
                .Include(p=>p.Tags)
                .FirstAsync(p => p.Id == model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Colors = model.ColorIds.Select(cId => _context.Colors.First(c => c.Id == cId)).ToList();
            product.Materials = model.MaterialIds.Select(mId => _context.Materials.First(m => m.Id == mId)).ToList();
            product.Tags = model.TagIds.Select(tId => _context.Tags.First(t => t.Id == tId)).ToList();
            product.IsAvailable = model.IsAvailable;

            var currentImages = product.Images.ToList();

            foreach(var image in currentImages)
			{
				if (!model.ImageIds!.Contains(image.Id))
				{
                    product.Images.Remove(image);
				}
			}

            foreach(var imageId in model.ImageIds!)
			{
                if(!currentImages.Any(i=> i.Id == imageId))
				{
                    product.Images.Add(new Image
                    {
                        Id = imageId
                    });
				}
			}

            await _context.SaveChangesAsync();

		}

		public async Task DeleteAsync(int productId)
		{
            if(!await ExistsByIdAsync(productId))
            {
                throw new ArgumentException();
            }
            
            var product = await _context.Products
                .FirstAsync(p => p.Id == productId);

            product.IsActive = false;
            await _context.SaveChangesAsync();
            await _galleryService.RemoveItemFromAllGalleries(productId);
        }

        public async Task<IEnumerable<ProductForCartDto>> GetProductsForCart(IEnumerable<int> productIds)
        {
            var productDtos = await _context.Products
                .Where(p => productIds.Contains(p.Id) && p.IsActive && p.IsAvailable)
                .Select(p => new ProductForCartDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageId = p.Images.First().Id,
                    Price = p.Price
                }).ToArrayAsync();

            return productDtos;
        }

        

        
    }
}
