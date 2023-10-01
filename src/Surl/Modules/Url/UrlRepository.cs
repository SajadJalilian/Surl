using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Surl.Shared.Api.Models.Configurations;

namespace Surl.Modules.Url;

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

    public Task CreateAsync(Url url) => _uriCollection.InsertOneAsync(url);
    public Task<Url> GetAsync(string id) => _uriCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task<IEnumerable<Url>> GetAsync() => await _uriCollection.Find(new BsonDocument()).ToListAsync();
    public Task PutAsync(Url url) => _uriCollection.ReplaceOneAsync(x => x.Id == url.Id, url);
    public Task RemoveAsync(string id) => _uriCollection.DeleteOneAsync(x => x.Id == id);
}