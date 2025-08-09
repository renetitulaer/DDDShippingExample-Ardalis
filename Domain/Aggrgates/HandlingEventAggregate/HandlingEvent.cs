using Ardalis.SharedKernel;
using Domain.Aggrgates.CargoAggregate;

namespace Domain.Aggrgates.HandlingEventAggregate;

/// <summary>
/// About the identity:
///     Another discussion with a domain expert concludes that Handling Events can be uniquely
///     identified by the combination of Cargo Id, completion time, and type.
/// </summary>
public class HandlingEvent : EntityBase 
{
    public TrackingId TrackingId { get; init; }
    public HandlingEventType Type { get; init; }
    public DateTime TimeStamp { get; init; }

    // This is not needed, in the configuration we have a converter which creates the object.
    //#pragma warning disable CS8618 // Required by Entity Framework
    //private HandlingEvent() {}

    public HandlingEvent(TrackingId trackingId, 
        DateTime timeStamp, HandlingEventType type)
    {
        TrackingId = trackingId;
        TimeStamp = timeStamp;
        Type = type;
    }
}
