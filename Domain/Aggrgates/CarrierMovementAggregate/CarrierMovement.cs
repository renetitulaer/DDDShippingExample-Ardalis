using Ardalis.SharedKernel;
using Domain.SeedWork;

namespace Domain.Aggrgates.CarrierMovementAggregate;

public class CarrierMovement : EntityBase
{
    /// <summary>
    /// QUESTION: what is a schedule?
    /// </summary>
    public int ScheduleId { get; private set; }
    public int FromLocation { get; private set; }
    public int ToLocation { get; private set; }


    // Needed for EF
    private CarrierMovement() {}

    internal CarrierMovement(int scheduleId, int fromLocation, 
        int toLocation)
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
    public void LoadOnto(int fromLocation, int toLocation)
    {
        FromLocation = fromLocation;
        ToLocation = toLocation;
    }

    public void Unload(int fromLocation, int toLocation)
    {
        FromLocation = fromLocation;
        ToLocation = toLocation;
    }
}
