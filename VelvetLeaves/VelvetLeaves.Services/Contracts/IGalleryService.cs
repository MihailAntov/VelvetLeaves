using VelvetLeaves.ViewModels.Gallery;

namespace VelvetLeaves.Services.Contracts
{
    public interface IGalleryService
	{
		Task<IEnumerable<GalleryViewModel>> AllGalleriesAsync();

		Task<IEnumerable<GalleryListViewModel>> AllGalleriesForEditAsync();

		Task<GalleryViewModel?> GetGalleryByIdAsync(int id);

		Task AddAsync(GalleryFormViewModel model);
	}
}
