using System;
using Domain;
using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CustomerAggregate;
using Domain.Aggrgates.HandlingEventAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistency.Configurations;

/// <summary>
/// Document this properly. Delivery history is part of the Cargo aggregate. 
/// </summary>
public class CargoSpecificationConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        // Cargo has an id of type TrackingId, EF does not know this type so we need a conversion
        var trackingIdConverter = new ValueConverter<TrackingId, int>(
                id => id.Value, // to database
                value => new TrackingId(value) // from database
            );

        builder.HasKey(x => x.Id); // The id of Cargo will be used as the primary key
        builder.Property(x => x.Id).HasColumnName("TrackingId"); // It will be mapped to tracking id
        builder.Property(x => x.Id)
            .HasConversion(trackingIdConverter) // the actual conversion
            .ValueGeneratedOnAdd(); // autonumber

        // We need to map RouteSpecification to two columns in the database
        builder.OwnsOne(e => e.DeliveryGoal, a =>
        {
            // Destination id is of type LocationIdentity which is unknown within EF so we need a conversion
            a.Property(x => x.DestinationId).HasConversion(    
                id => id.Value, // to database
                value => new LocationIdentity(value) // from database
            );
            a.Property(x => x.DueDate).HasColumnName("DeliveryGoalArrivelTime");
            a.Property(x => x.DestinationId).HasColumnName("DeliveryGoalDestinationId");
        });

        // Delivery history is of type Handlinge events. The delivery history should be persisted to Handling events
        builder.OwnsMany(c => c.DeliveryHistory, d =>
        {
            // HandlingEventType is a SmartEnum, EF does not know this type so we need a conversion
            d.Property(d => d.Type).HasConversion(
                id => id.Value, // to database
                value => HandlingEventType.FromValue(value) // from database
            );
            d.WithOwner().HasForeignKey("TrackingId"); // Needs to be set explicitly, because otherwise it will use CargoId (based on naming conventions)
            d.Ignore(e => e.Id); // Handling event has an id which is not used, the key is a combined key, see below
            d.HasKey(e => new { e.Type, e.TrackingId, e.TimeStamp }); // Combined key
        });
    }
}
