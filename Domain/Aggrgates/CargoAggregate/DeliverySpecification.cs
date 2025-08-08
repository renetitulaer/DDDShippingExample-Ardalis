using Ardalis.SharedKernel;

namespace Domain.Aggrgates.CargoAggregate;

/// <summary>
/// RouteSpecification defines what is desired:
/// Destination
/// Arrival deadline
/// </summary>
public class DeliverySpecification : ValueObject 
{
    // Needed for EF
    private DeliverySpecification() : this(DateTime.MinValue, new LocationIdentity(0)) { }

    public DateTime ArrivalTime { get; init; }
    public LocationIdentity DestinationId { get; init; }

    public DeliverySpecification(DateTime arrivalTime, LocationIdentity destinationId)
    {
        ArrivalTime = arrivalTime;
        DestinationId = destinationId;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ArrivalTime;
        yield return DestinationId;
    }
}
