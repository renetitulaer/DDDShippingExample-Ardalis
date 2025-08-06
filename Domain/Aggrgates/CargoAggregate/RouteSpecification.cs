using Ardalis.SharedKernel;
using Domain.SeedWork;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Aggrgates.CargoAggregate;

/// <summary>
/// RouteSpecification defines what is desired:
/// Destination
/// Arrival deadline
/// </summary>
public class RouteSpecification : ValueObject 
{
    // Needed for EF
    private RouteSpecification() : this(DateTime.MinValue, 0) { }

    public DateTime ArrivalTime { get; init; }
    public int DestinationId { get; init; }

    public RouteSpecification(DateTime arrivalTime, int destinationId)
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
