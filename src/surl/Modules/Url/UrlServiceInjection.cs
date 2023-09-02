using surl.Modules.Url.CreateUrl;

namespace surl.Modules.Url;

public static class UrlServiceInjection
{
    public static IServiceCollection AddUrlServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateUrlHandler, CreateUrlHandler>();
        services.AddSingleton<UrlRepository>();

        return services;
    }
}