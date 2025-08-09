using Ardalis.SharedKernel;

namespace Domain.Aggrgates.CarrierMovementAggregate;

public class CarrierMovement : EntityBase
{
    public LocationIdentity FromLocation { get; private set; }
    public LocationIdentity ToLocation { get; private set; }

    #pragma warning disable CS8618 // Required by Entity Framework
    private CarrierMovement() { }

    internal CarrierMovement(int scheduleId, LocationIdentity fromLocation,
        LocationIdentity toLocation)
    {
        Id = scheduleId;
        FromLocation = fromLocation;
        ToLocation = toLocation;
    }
    
    /// <summary>
    /// Updates the source and destination locations for a transfer operation.
    /// </summary>
    /// <param name="fromLocation">The identifier of the source location. Must be a valid location identifier.</param>
    /// <param name="toLocation">The identifier of the destination location. Must be a valid location identifier.</param>
    public void LoadOnto(LocationIdentity fromLocation, LocationIdentity toLocation)
    {
        FromLocation = fromLocation;
        ToLocation = toLocation;
    }

    public void Unload(LocationIdentity fromLocation, LocationIdentity toLocation)
    {
        FromLocation = fromLocation;
        ToLocation = toLocation;
    }
}
