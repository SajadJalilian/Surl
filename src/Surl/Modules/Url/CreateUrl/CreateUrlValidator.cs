using FluentValidation;

namespace Surl.Modules.Url.CreateUrl;

public class CreateUrlValidator : AbstractValidator<CreateUrlCommand>
{
    public CreateUrlValidator()
    {
        RuleFor(x => x.Url)
            .Length(2, 1500)
            .WithState(_ => CreateUrlError.BasketItemsMaxQuantityExceeded);
    }
}