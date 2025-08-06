using Domain.Aggrgates.CarrierMovementAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistency.Configurations;

public class CarrierMovementConfiguration : IEntityTypeConfiguration<CarrierMovement>
{
    public void Configure(EntityTypeBuilder<CarrierMovement> builder)
    {
        builder.HasKey(x => x.ScheduleId);

        // TODO: Configure the rest of the properties as needed
        //builder.HasOne(x => x.FromLocation).WithMany().OnDelete(DeleteBehavior.NoAction);
        //builder.HasOne(x => x.ToLocation).WithMany().OnDelete(DeleteBehavior.NoAction);
    }
}
