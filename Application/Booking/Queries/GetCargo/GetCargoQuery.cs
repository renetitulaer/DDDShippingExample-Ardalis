using Domain.Aggrgates.CargoAggregate;

namespace Application.Booking.Queries.GetCargo;
public class GetCargoQuery(TrackingId trackingId)
{
    public TrackingId TrackingId { get; } = trackingId;
}
