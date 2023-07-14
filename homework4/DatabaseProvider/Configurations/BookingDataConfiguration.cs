using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProvider.Configurations
{
    public class BookingDataConfiguration : IEntityTypeConfiguration<BookingData>
    {
        public void Configure(EntityTypeBuilder<BookingData> builder)
        {
            builder.ToTable("BookingData").HasKey(bd => bd.Id);

            builder.Property(bd => bd.StartDate).IsRequired();

            builder.Property(bd => bd.EndDate).IsRequired();

            builder.Property(bd => bd.Pay).IsRequired();

            builder.HasMany(bd => bd.Clients)
                .WithMany(c => c.BookingData)
                .UsingEntity<Dictionary<string, object>>(
                    "BookingDataClient",
                    j => j
                        .HasOne<Client>()
                        .WithMany()
                        .HasForeignKey("ClientId"),
                    j => j
                        .HasOne<BookingData>()
                        .WithMany()
                        .HasForeignKey("BookingDataId"),
                    j =>
                    {
                        j.HasKey("ClientId", "BookingDataId");
                        j.ToTable("BookingDataClient");
                    });
        }
    }
}
