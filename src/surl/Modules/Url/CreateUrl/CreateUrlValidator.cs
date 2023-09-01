using FluentValidation;

namespace surl.Modules.Url.CreateUrl;

public class CreateUrlValidator : AbstractValidator<CreateUrlCommand>
{
    public CreateUrlValidator()
    {
        RuleFor(x => x.Url)
            .Length(2, 1500)
            .WithMessage("Url length must be between 2 and 1500");
    }
}