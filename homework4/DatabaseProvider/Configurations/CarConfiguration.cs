using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseProvider.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car").HasKey(cr => cr.Id);

            builder.Property(cr => cr.Name).IsRequired().HasMaxLength(100);

            builder.Property(cr => cr.CreationDate).IsRequired(); 

            builder.Property(cr => cr.Price).IsRequired(); 

            builder.Property(cr => cr.Rating).IsRequired(); 

            builder.HasOne(cr => cr.Client).WithMany(c => c.Cars).HasForeignKey(cr => cr.ClientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
