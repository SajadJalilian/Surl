using FluentValidation;

namespace Surl.Modules.Url.GetUrl;

public class GetUrlValidator : AbstractValidator<GetUrlCommand>
{
    public GetUrlValidator()
    {
        RuleFor(x => x.Key)
            .Length(9, 12)
            .WithState(_ => GetUrlError.KeyLengthIdInvalid);
    }
}