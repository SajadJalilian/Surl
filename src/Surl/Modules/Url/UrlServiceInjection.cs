
using Surl.Modules.Url.CreateUrl;
using Surl.Modules.Url.GetUrl;

namespace Surl.Modules.Url;

public static class UrlServiceInjection
{
    public static IServiceCollection AddUrlServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateUrlHandler, CreateUrlHandler>();
        services.AddScoped<IGetUrlHandler, GetUrlHandler>();
        services.AddSingleton<UrlRepository>();

        return services;
    }
}