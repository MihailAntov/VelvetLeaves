

namespace VelvetLeaves.Data.Configuration
{
	public class ImageDatabaseSettings
	{
		public string ConnectionString { get; set; } = null!;

		public string DatabaseName { get; set; } = null!;

		public string ImagesCollectionName { get; set; } = null!;
	}
}
