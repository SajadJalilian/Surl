using surl.Shared.Communal;

namespace surl.Modules.Url.CreateUrl;

public class CreateUrlError
{
    public static ErrorModel BasketItemsMaxQuantityExceeded = new(
        code: 1,
        title: "OtcProduct Error",
        (
            Language: Language.English,
            Message: "Url length must be between 2 and 1500"
        ));
}