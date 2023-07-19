

using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services
{
	public class ColorService : IColorService
	{
		public async Task<IEnumerable<ColorSelectViewModel>> GetColorOptionsAsync(int? categoryId, int? subcategoryId)
		{
			throw new NotImplementedException();
		}
	}
}
