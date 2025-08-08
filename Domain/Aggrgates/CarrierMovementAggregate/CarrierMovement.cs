using Ardalis.SharedKernel;
using Domain.SeedWork;

namespace Domain.Aggrgates.CarrierMovementAggregate;

public class CarrierMovement : EntityBase
{
    /// <summary>
    /// QUESTION: what is a schedule?
    /// Another bounded context is responsible for the schedule and will create this id.
    /// </summary>
    public int ScheduleId { get; private set; }
    public LocationIdentity FromLocation { get; private set; }
    public LocationIdentity ToLocation { get; private set; }


    // Needed for EF
    private CarrierMovement() {}

    internal CarrierMovement(int scheduleId, LocationIdentity fromLocation,
        LocationIdentity toLocation)
    {
        ScheduleId = scheduleId;
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
