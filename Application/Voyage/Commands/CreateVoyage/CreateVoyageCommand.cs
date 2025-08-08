using Domain.Aggrgates.CargoAggregate;

namespace Application.Voyage.Commands.CreateMovement;
public class CreateVoyageCommand(TrackingId trackingId)
{
    public TrackingId TrackingId { get; } = trackingId ?? throw new ArgumentNullException(nameof(trackingId));
}
