using Microsoft.AspNetCore.Mvc;
using surl.Modules.Url.CreateUrl;

namespace surl.Modules.Url;

public static class UrlApiRegistration
{
    private const string Route = "urls/";

    public static WebApplication RegisterUrlApis(this WebApplication app)
    {
        app.MapPost(Route, async (ICreateUrlHandler createUrlHandler, [FromBody] CreateUrlRequest request) =>
        {
            var result = await createUrlHandler.CreateUrl(new CreateUrlCommand(request.Url));
            return Results.Ok(result);
        });

        return app;
    }
}