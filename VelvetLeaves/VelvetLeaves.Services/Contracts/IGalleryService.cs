using VelvetLeaves.ViewModels.Gallery;

namespace VelvetLeaves.Services.Contracts
{
    public interface IGalleryService
	{
		Task<IEnumerable<GalleryViewModel>> AllGalleriesAsync();

		Task<GalleryViewModel> GetGalleryByIdAsync(int id);

		Task AddAsync(GalleryFormViewModel model);

		Task<bool> ProductInGallery(int productId, int galleryId);

		Task MoveRight(int productId, int galleryId);
		Task MoveLeft(int productId, int galleryId);
		Task DeleteItem(int productId, int galleryId);

		Task<AddToGalleryViewModel> GetItemsToAddAsync(int galleryId);

		Task AddItemsToGalleryAsync(int galleryId, IEnumerable<int> items);

		Task<GalleryEditFormViewModel> GetGalleryEditFormAsync(int galleryId);

		Task EditAsync(GalleryEditFormViewModel model);

		Task DeleteAsync(int galleryId);

		Task RemoveItemFromAllGalleries(int productId);

		Task<bool> ExistsByIdAsync (int galleryId);	
	}
}
