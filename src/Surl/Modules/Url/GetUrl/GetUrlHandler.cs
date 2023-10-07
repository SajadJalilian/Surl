using Surl.Shared.Communal;

namespace Surl.Modules.Url.GetUrl;

public interface IGetUrlHandler
{
    Task<OperationResult> GetUrl(GetUrlCommand command);
}

public class GetUrlHandler : IGetUrlHandler
{
    private readonly UrlRepository _urlRepository;

    public GetUrlHandler(UrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<OperationResult> GetUrl(GetUrlCommand command)
    {
        var validations = await Validations(command);
        if (!validations.IsValid)
            return new OperationResult(OperationResultStatus.InvalidRequest, value: validations.ErrorMessage);

        var url = await _urlRepository.GetAsync(command.Key);

        return new OperationResult(OperationResultStatus.Ok, value: url.GetUrlResult());
    }

    private static async Task<ValidationResult> Validations(GetUrlCommand command)
    {
        var validator = new GetUrlValidator();
        var validation = await validator.ValidateAsync(command);

        return !validation.IsValid
            ? new ValidationResult(IsValid: false, ErrorMessage: validation.GetFirstCustomState())
            : new ValidationResult(IsValid: true, null);
    }
}