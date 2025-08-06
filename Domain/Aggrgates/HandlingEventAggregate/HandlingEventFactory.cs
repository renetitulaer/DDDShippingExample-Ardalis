using Domain.Aggrgates.CarrierMovementAggregate;

namespace Domain.Aggrgates.HandlingEventAggregate;
public class HandlingEventFactory
{
    public HandlingEvent CreateHandlingEvent(int trackingId, 
        DateTime timeStamp,
        HandlingEventType eventType)
    {
        var handlingEvent = new HandlingEvent(trackingId, 
            timeStamp, eventType);
        return handlingEvent;
    }
}
