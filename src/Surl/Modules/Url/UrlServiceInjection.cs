
using Surl.Modules.Url.CreateUrl;

namespace Surl.Modules.Url;

public static class UrlServiceInjection
{
    public static IServiceCollection AddUrlServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateUrlHandler, CreateUrlHandler>();
        services.AddSingleton<UrlRepository>();

        return services;
    }
}