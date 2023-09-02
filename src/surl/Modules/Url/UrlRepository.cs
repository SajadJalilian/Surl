using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using surl.Shared.Api.Models.Configurations;

namespace surl.Modules.Url;

public class UrlRepository
{
    private readonly IMongoCollection<Url> _uriCollection;

    public UrlRepository(IOptions<MongoDbConfigurations> mongoDbConfigs)
    {
        var mongoClient = new MongoClient(
            mongoDbConfigs.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbConfigs.Value.DatabaseName);

        _uriCollection = mongoDatabase.GetCollection<Url>(
            mongoDbConfigs.Value.ConnectionName);
    }

    public async Task Create(Url url) => await _uriCollection.InsertOneAsync(url);
    public async Task<Url> Get(string id) => await _uriCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task<IEnumerable<Url>> Get() => await _uriCollection.Find(new BsonDocument()).ToListAsync();
    public async Task Put(Url url) => await _uriCollection.ReplaceOneAsync(x => x.Id == url.Id, url);
    public async Task Remove(string id) => await _uriCollection.DeleteOneAsync(x => x.Id == id);
}