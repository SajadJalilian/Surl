namespace surl.Modules.Url.CreateUrl;

public interface ICreateUrlHandler
{
    Task<Url> CreateUrl(CreateUrlCommand command);
}

public class CreateUrlHandler : ICreateUrlHandler
{
    private readonly UrlRepository _urlRepository;
    private static Random random = new Random();

    public CreateUrlHandler(UrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<Url> CreateUrl(CreateUrlCommand command)
    {
        // Validation
        var validator = new CreateUrlValidator();
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
            }
        }

        var url = new Url
        {
            Key = RandomString(10),
            UrlBody = command.Url
        };

        await _urlRepository.Create(url);

        return url;
    }

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}