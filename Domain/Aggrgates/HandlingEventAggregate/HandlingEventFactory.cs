using Domain.Aggrgates.CargoAggregate;

namespace Domain.Aggrgates.HandlingEventAggregate;
public class HandlingEventFactory
{
    public HandlingEvent CreateHandlingEvent(TrackingId trackingId, 
        DateTime timeStamp,
        HandlingEventType eventType)
    {
        var handlingEvent = new HandlingEvent(trackingId, 
            timeStamp, eventType);
        return handlingEvent;
    }
}
