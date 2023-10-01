using Microsoft.AspNetCore.Mvc;
using Surl.Modules.Url.CreateUrl;
using Surl.Shared.Communal;

namespace Surl.Modules.Url;

public static class UrlApiRegistration
{
    private const string Route = "urls/";

    public static void RegisterUrlApis(this WebApplication app)
    {
        app.MapPost(Route, async (ICreateUrlHandler createUrlHandler, [FromBody] CreateUrlRequest request) =>
        {
            var result = await createUrlHandler.CreateUrl(new CreateUrlCommand(request.Url));
            return app.ReturnResponse(result);
        });
    }
}