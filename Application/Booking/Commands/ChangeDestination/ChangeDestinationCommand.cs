using Domain;
using Domain.Aggrgates.CargoAggregate;

namespace Application.Booking.Commands.ChangeDestination;
public record ChangeDestinationCommand(TrackingId trackingId, LocationIdentity newDestinationId)
{
    public TrackingId TrackingId { get; init; } = trackingId;
    public LocationIdentity NewDestinationId { get; init; } = newDestinationId;
}
