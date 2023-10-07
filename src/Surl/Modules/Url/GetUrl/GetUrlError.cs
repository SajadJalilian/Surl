using Surl.Shared.Communal;

namespace Surl.Modules.Url.GetUrl;

public class GetUrlError
{
    public static ErrorModel KeyLengthIdInvalid = new(
        code: 1,
        title: "OtcProduct Error",
        (
            Language: Language.English,
            Message: "Key length is invalid"
        ));
}