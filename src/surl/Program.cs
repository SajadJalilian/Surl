using surl.Modules.Url;
using surl.Shared.Api.Extensions.DependencyInjections;
using surl.Shared.Api.Extensions.Middlewares;

#region Add services to the container.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguredDatabase(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUrlServices();

#endregion

#region Pipeline

var app = builder.Build();

app.UseRouting();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (environment is "Local" or "Development" or "NewFeature" or "Staging")
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.UseConfiguredMigration();
app.RegisterUrlApis();

app.Run();

#endregion