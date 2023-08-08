

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class MenuServiceUnitTests
    {
        private DbContextOptions<VelvetLeavesDbContext> _dbContextOptions;
        private MenuService _menuService;
        private VelvetLeavesDbContext _dbContext;


        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;
            _dbContext = new VelvetLeavesDbContext(_dbContextOptions);


            _menuService = new MenuService(_dbContext);
        }
		[TearDown]
        public async Task TearDown()
		{
            await _dbContext.SaveChangesAsync();
            await _dbContext.DisposeAsync();
		}

        [Test]
        public async Task GetMenuCategoriesAsync_ReturnsMenuCategoriesWithSubcategories()
        {

            var category1 = new Category 
            { 
                Id = 1, 
                Name = "Category 1", 
                IsActive = true, 
                ImageId = "c1img", 
                Subcategories = new List<Subcategory> 
                { 
                    new Subcategory 
                    { 
                        Id = 1, 
                        Name = "Subcategory 1", 
                        IsActive = true,
                        ImageId = "sc1img" 
                    },
                    new Subcategory
                    {
                        Id = 2,
                        Name = "Subcategory 2",
                        IsActive = true,
                        ImageId = "sc2img"
                    },
                    new Subcategory
                    {
                        Id = 3,
                        Name = "Subcategory 3",
                        IsActive = false,
                        ImageId = "sc3img"
                    }
                } 
            };
            var category2 = new Category 
            { 
                Id = 2, 
                Name = "Category 2", 
                IsActive = false, 
                ImageId = "c2img",
                Subcategories = new List<Subcategory> 
                { 
                    new Subcategory 
                    { 
                        Id = 4, 
                        IsActive = false,
                        Name = "Subcategory 4" , 
                        ImageId = "sc4img" 
                    } 
                } 
            };
            var category3 = new Category
            {
                Id = 3,
                Name = "Category 3",
                IsActive = true,
                ImageId = "c3img",
                Subcategories = new List<Subcategory>
                {
                    new Subcategory
                    {
                        Id = 5,
                        IsActive = true,
                        Name = "Subcategory 5" ,
                        ImageId = "sc5img"
                    }
                }
            };

            _dbContext.Categories.Add(category1);
            _dbContext.Categories.Add(category2);
            _dbContext.Categories.Add(category3);
            _dbContext.SaveChanges();

            // Act
            var result = await _menuService.GetMenuCategoriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count());

            var categoryViewModel1 = result.First();
            Assert.AreEqual(category1.Id, categoryViewModel1.Id);
            Assert.AreEqual(category1.Name, categoryViewModel1.Name);
            Assert.AreEqual(category1.ImageId, categoryViewModel1.ImageId);
            Assert.AreEqual(2, categoryViewModel1.Subcategories.Count());

            var subcategoryViewModel1 = categoryViewModel1.Subcategories.First();
            Assert.AreEqual(category1.Subcategories.First().Id, subcategoryViewModel1.Id);
            Assert.AreEqual(category1.Subcategories.First().Name, subcategoryViewModel1.Name);

            var categoryViewModel2 = result.ElementAt(1);
            Assert.AreEqual(category3.Id, categoryViewModel2.Id);
            Assert.AreEqual(category3.Name, categoryViewModel2.Name);
            Assert.AreEqual(category3.ImageId, categoryViewModel2.ImageId);
            Assert.AreEqual(1, categoryViewModel2.Subcategories.Count());

            var subcategoryViewModel2 = categoryViewModel2.Subcategories.First();
            Assert.AreEqual(category3.Subcategories.First().Id, subcategoryViewModel2.Id);
            Assert.AreEqual(category3.Subcategories.First().Name, subcategoryViewModel2.Name);
        }

       
    }
}
