using surl.Modules.Url;
using surl.Shared.Api.Models.Configurations;

#region Add services to the container.

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbConfigurations>(builder
    .Configuration.GetSection(MongoDbConfigurations.Key));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddUrlServices();

#endregion

#region Pipeline

var app = builder.Build();

app.MapHealthChecks("/health");
// app.UseHttpsRedirection();
// app.UseAuthorization();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (environment is "Local" or "Development" or "NewFeature" or "Staging")
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

app.RegisterUrlApis();

app.Run();

#endregion