using Domain;

namespace Application.Booking.Commands.CreateCargo;
public record CreateCargoCommand(string customerName, 
    LocationIdentity destinationLocationId, DateTime deliveryGoal)
{
    public string CustomerName { get; init; } = customerName;
    public LocationIdentity DestinationLocationId { get; init; } = destinationLocationId;
    public DateTime DeliveryGoal { get; init; } = deliveryGoal;
}
