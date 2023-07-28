using VelvetLeaves.ViewModels.Gallery;

namespace VelvetLeaves.Services.Contracts
{
    public interface IGalleryService
	{
		Task<IEnumerable<GalleryViewModel>> AllGalleriesAsync();

		Task<GalleryViewModel?> GetGalleryByIdAsync(int id);

		Task AddAsync(GalleryFormViewModel model);
	}
}
