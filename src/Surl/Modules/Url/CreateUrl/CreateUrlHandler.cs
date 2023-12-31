using Surl.Shared.Communal;

namespace Surl.Modules.Url.CreateUrl;

public interface ICreateUrlHandler
{
    Task<OperationResult> CreateUrl(CreateUrlCommand command);
}

public class CreateUrlHandler : ICreateUrlHandler
{
    private readonly UrlRepository _urlRepository;

    public CreateUrlHandler(UrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<OperationResult> CreateUrl(CreateUrlCommand command)
    {
        var validations = await Validations(command);
        if (!validations.IsValid)
            return new OperationResult(OperationResultStatus.InvalidRequest, value: validations.ErrorMessage);

        var url = new Url(command.Url);
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
}