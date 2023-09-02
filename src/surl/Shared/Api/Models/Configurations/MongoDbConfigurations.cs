namespace surl.Shared.Api.Models.Configurations;

public class MongoDbConfigurations
{
    public const string Key = "MongoDB";

    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
    public required string ConnectionName { get; set; }
}