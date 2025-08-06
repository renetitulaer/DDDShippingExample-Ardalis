using Domain.Aggrgates.CargoAggregate;

namespace Application.Booking.Commands.ChangeDestination;
public record ChangeDestinationCommand(int trackingId, int newDestinationId)
{
    public int TrackingId { get; init; } = trackingId;
    public int NewDestinationId { get; init; } = newDestinationId;
}
