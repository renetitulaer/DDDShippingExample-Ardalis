using Ardalis.SharedKernel;

namespace Domain.Aggrgates.HandlingEventAggregate;

/// <summary>
/// About the identity:
///     Another discussion with a domain expert concludes that Handling Events can be uniquely
///     identified by the combination of Cargo Id, completion time, and type.
/// </summary>
public class HandlingEvent : EntityBase 
{
    public int TrackingId { get; init; }
    public HandlingEventType Type { get; init; }
    public DateTime TimeStamp { get; init; }
    //public CarrierMovement CarrierMovement { get; init; }
    //public Cargo Loaded => ShippingDbContext!.Cargos.Single(c => c.TrackingId == _trackingId);
    
    // Needed for EF?
    private HandlingEvent() {}

    //TODO: an handling event has no reference to carrie movement or location.
    // Add movement

    public HandlingEvent(int trackingId, 
        DateTime timeStamp, HandlingEventType type)
    {
        //CarrierMovement = carrierMovement;
        TrackingId = trackingId;
        TimeStamp = timeStamp;
        Type = type;
    }

    //public void Load(CarrierMovement carrierMovement)
    //{
    //    carrierMovement.LoadOnto(carrierMovement.FromLocation, carrierMovement.ToLocation);
    //}

    //public static HandlingEvent Load(string location, 
    //    DateTimeOffset dateTimeOffset, int voyageId)
    //{
    //    return new HandlingEvent(
    //        location, 
    //        DateTime.Now, 
    //        HandlingEventType.Load,
    //        voyageId);
    //}

    //public static HandlingEvent UnLoad(string location,
    //    DateTimeOffset dateTimeOffset, int voyageId)
    //{
    //    return new HandlingEvent(
    //        location,
    //        DateTime.Now,
    //        HandlingEventType.Unload,
    //        voyageId);
    //}

    //public static HandlingEvent Receive(string location,
    //    DateTimeOffset dateTimeOffset, int voyageId)
    //{
    //    return new HandlingEvent(
    //        location,
    //        DateTime.Now,
    //        HandlingEventType.Receive,
    //        voyageId);
    //}
}
