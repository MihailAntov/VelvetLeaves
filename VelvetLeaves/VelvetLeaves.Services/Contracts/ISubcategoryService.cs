

using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.Services.Contracts
{
	public interface ISubcategoryService
	{
		Task AddAsync(string name, int categoryId, string imageId);

		Task<IEnumerable<SubcategorySelectViewModel>> AllSubcategoriesAsync();
	}
}
