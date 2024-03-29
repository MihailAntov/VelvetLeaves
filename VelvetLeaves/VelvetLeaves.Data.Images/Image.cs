﻿
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VelvetLeaves.Data.ObjectDatabase
{
    public class Image
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }

        [BsonElement("Url")]
        public string Content { get; set; } = null!;

    }
}
