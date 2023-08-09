

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VelvetLeaves.Data.ObjectDatabase
{
    public class AppPreferences
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }

        [BsonElement("BackgroundImageId")]
        public string BackGroundImageId { get; set; } = null!;


        [BsonElement("RootProductsName")]
        public string RootNavigationName { get; set; } = null!;

        [BsonElement("Currency")]
        public string Currency { get; set; } = null!;

        [BsonElement("FavoriteIcon")]
        public string FavoriteIcon { get; set; } = null!;

        [BsonElement("FavoriteColor")]
        public string FavoriteColor { get; set; } = null!;

        [BsonElement("Description")]
        public string Description { get; set; } = null!;

    }
}
