using Microsoft.EntityFrameworkCore;
using surl.Shared.Persistence;

namespace surl.Modules.Url.CreateUrl;

public interface ICreateUrlHandler
{
    Task<Url> CreateUrl(CreateUrlCommand command);
}

public class CreateUrlHandler : ICreateUrlHandler
{
    private readonly AppDbContext _context;
    private readonly DbSet<Url> _urls;

    public CreateUrlHandler(AppDbContext context)
    {
        _context = context;
        _urls = context.Set<Url>();
    }

    public async Task<Url> CreateUrl(CreateUrlCommand command)
    {
        // Validation
        var validator = new CreateUrlValidator();
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
            }
        }

        var url = new Url
        {
            // UrlBody = command.Url
            UrlBody = $"http://{command.Url}"
        };

        // _urls.Add(url);
        // await _context.SaveChangesAsync();

        return url;
    }
}