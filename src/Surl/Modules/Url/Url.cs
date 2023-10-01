using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Surl.Modules.Url;

public class Url
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement] public required string Key { get; set; }
    [BsonElement] public required string UrlBody { get; set; }
}