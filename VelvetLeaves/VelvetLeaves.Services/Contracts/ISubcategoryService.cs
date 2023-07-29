

using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.Services.Contracts
{
	public interface ISubcategoryService
	{
		Task AddAsync(string name, int categoryId, string imageId);

		Task<IEnumerable<SubcategorySelectViewModel>> AllSubcategoriesAsync();
		Task<IEnumerable<SubcategorySelectViewModel>> SubcategoriesByCategoryIdAsync(int categoryId);
		Task<int> GetDefaultSubcategoryIdAsync(int categoryId);

		Task<SubcategoryEditFormViewModel> GetForEditAsync(int subcategoryId);

		Task EditAsync(SubcategoryEditFormViewModel model);

		Task DeleteAsync(int subcategoryId);
	}
}
