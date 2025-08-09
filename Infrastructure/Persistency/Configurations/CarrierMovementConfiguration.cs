using Domain;
using Domain.Aggrgates.CarrierMovementAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistency.Configurations;

public class CarrierMovementConfiguration : IEntityTypeConfiguration<CarrierMovement>
{
    public void Configure(EntityTypeBuilder<CarrierMovement> builder)
    {
        var locationIdConverter = new ValueConverter<LocationIdentity, int>(
              id => id.Value, // to database
              value => new LocationIdentity(value) // from database
          );

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
          .HasColumnName("ScheduleId");

        // EF does not know the type LocationIdentity, so we need to convert it
        builder.Property(x => x.FromLocation)
          .HasColumnName("FromLocationLocationId")
          .HasConversion(locationIdConverter);
        builder.Property(x => x.ToLocation)
          .HasColumnName("ToLocationLocationId")
          .HasConversion(locationIdConverter);
    }
}
