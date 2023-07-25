

using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
	public class SubcategoryService : ISubcategoryService
	{

		private readonly VelvetLeavesDbContext _context;
        public SubcategoryService(VelvetLeavesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(string name, int categoryId, string imageId)
		{
			var subcategory = new Subcategory()
			{
				Name = name,
				CategoryId = categoryId,
				ImageId = imageId
			};

			await _context.Subcategories.AddAsync(subcategory);
			await _context.SaveChangesAsync();


		}
	}
}
