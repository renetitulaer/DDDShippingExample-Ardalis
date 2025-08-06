using Domain.Aggrgates.CargoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistency.Configurations;

/// <summary>
/// Document this properly. Delivery history is part of the Cargo aggregate. 
/// </summary>
public class CargoSpecificationConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Id)
            .HasColumnName("TrackingId");

        builder.OwnsOne(e => e.RouteSpecification, a =>
        {
            a.Property(x => x.ArrivalTime).HasColumnName("DeliveryGoalArrivelTime");
            a.Property(x => x.DestinationId).HasColumnName("DeliveryGoalDestinationId");
        });

        builder.OwnsMany(c => c.DeliveryHistory, d =>
        {
            d.WithOwner().HasForeignKey("TrackingId");
            d.Ignore(e => e.Id);
            d.Property(e => e.Type);
            d.Property(e => e.TimeStamp);
            d.HasKey(e => new { e.Type, e.TrackingId, e.TimeStamp });
        });
    }
}
