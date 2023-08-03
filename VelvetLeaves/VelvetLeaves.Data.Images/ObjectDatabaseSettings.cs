namespace VelvetLeaves.Data.ObjectDatabase
{
    public class ObjectDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ImagesCollectionName { get; set; } = null!;

        public string AppPreferencesCollectionName { get; set; } = null!;


    }
}
