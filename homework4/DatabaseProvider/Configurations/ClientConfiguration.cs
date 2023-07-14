using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(c => c.Id);

            builder.Property(c => c.Birthday).IsRequired();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Address).IsRequired().HasMaxLength(100);

        }
    }
}
