namespace Surl.Modules.Url.CreateUrl;

public record CreateUrlRequest(string Url)
{
    public required string Url { get; init; } = Url;
}