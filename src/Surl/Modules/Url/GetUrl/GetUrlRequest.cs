namespace Surl.Modules.Url.GetUrl;

public record GetUrlRequest(string Key)
{
    public required string Key { get; init; } = Key;
}