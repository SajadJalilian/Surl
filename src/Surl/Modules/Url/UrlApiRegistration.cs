using Microsoft.AspNetCore.Mvc;
using Surl.Modules.Url.CreateUrl;
using Surl.Modules.Url.GetUrl;
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
        app.MapGet(Route + "{key}", async (IGetUrlHandler getUrlHandler, [FromRoute] string key) =>
        {
            var result = await getUrlHandler.GetUrl(new GetUrlCommand(key));
            return app.ReturnResponse(result);
        });
    }
}