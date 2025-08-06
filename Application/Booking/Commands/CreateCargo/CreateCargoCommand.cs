namespace Application.Booking.Commands.CreateCargo;
public record CreateCargoCommand(string customerName, int destinationLocationId)
{
    public string CustomerName { get; init; } = customerName;
    public int DestinationLocationId { get; init; } = destinationLocationId;
}
