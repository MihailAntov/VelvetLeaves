

using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.Services.Contracts
{
	public interface IProductSeriesService
	{
		public Task<IEnumerable<ProductSeriesSelectViewModel>> ProductSeriesBySubcategoryIdAsync(int subcategoryId);
		public Task<int> GetDefaultProductSeriesIdAsync(int subcategoryId);

		public Task AddAsync(ProductSeriesFormViewModel model);

		public Task<ProductSeriesDefaultValues> GetDefaultValues(int productSeriesId);

		public Task<ProductSeriesFormViewModel> GetProductSeriesByIdAsync(int productSeriesId);
		public Task EditAsync(int productSeriesId, ProductSeriesFormViewModel model);

		Task DeleteAsync(int productSeriesId);
	}
}
