using Microsoft.AspNetCore.Identity;
using surl.Shared.Communal;

namespace surl.Modules.Url.CreateUrl;

public interface ICreateUrlHandler
{
    Task<OperationResult> CreateUrl(CreateUrlCommand command);
}

public class CreateUrlHandler : ICreateUrlHandler
{
    private readonly UrlRepository _urlRepository;
    private static Random random = new Random();

    public CreateUrlHandler(UrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<OperationResult> CreateUrl(CreateUrlCommand command)
    {
        var validations = await Validations(command);
        if (!validations.IsValid)
            return new OperationResult(OperationResultStatus.InvalidRequest, value: validations.ErrorMessage);

        var url = new Url
        {
            Key = RandomString(10),
            UrlBody = command.Url
        };

        await _urlRepository.CreateAsync(url);

        return new OperationResult(OperationResultStatus.Created, value: url);
    }

    private static async Task<ValidationResult> Validations(CreateUrlCommand command)
    {
        var validator = new CreateUrlValidator();
        var validation = await validator.ValidateAsync(command);

        return !validation.IsValid
            ? new ValidationResult(IsValid: false, ErrorMessage: validation.GetFirstCustomState())
            : new ValidationResult(IsValid: true, null);
    }

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}