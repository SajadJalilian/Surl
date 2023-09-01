using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace surl.Modules.Url;

public class UrlEntityConfigurations: IEntityTypeConfiguration<Url>
{
    public void Configure(EntityTypeBuilder<Url> builder)
    {
        builder.ToTable("Urls");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Key)
            .HasMaxLength(10);

        builder.Property(x => x.UrlBody)
            .HasMaxLength(1500);
    }
}