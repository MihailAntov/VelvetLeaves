

using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.Services.Contracts
{
	public interface IProductSeriesService
	{
		public Task<IEnumerable<ProductSeriesSelectViewModel>> ProductSeriesBySubcategoryIdAsync(int subcategoryId);
		Task<int> GetDefaultProductSeriesIdAsync(int subcategoryId);
	}
}
