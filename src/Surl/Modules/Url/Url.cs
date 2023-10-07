using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Surl.Modules.Url;

public class Url
{
    private static Random random = new Random();

    public Url(string urlBody)
    {
        UrlBody = urlBody;
        Key = RandomString();
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; private set; }

    [BsonElement] public string Key { get; private set; }
    [BsonElement] public string UrlBody { get; private set; }

    private static string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}

public record UrlResult(string Key, string Body);

public static class UrlExtensions
{
    public static UrlResult GetUrlResult(this Url url)
    {
        return new UrlResult(url.Key, url.UrlBody);
    }
}