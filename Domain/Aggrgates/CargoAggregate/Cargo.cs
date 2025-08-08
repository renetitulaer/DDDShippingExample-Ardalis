using Ardalis.SharedKernel;
using Domain.Aggrgates.HandlingEventAggregate;

namespace Domain.Aggrgates.CargoAggregate;

public class Cargo : EntityBase<Cargo, TrackingId>, IAggregateRoot 
{
    public int CustomerId { get; private set; }

    public DeliverySpecification DeliveryGoal { get; private set; }

    private readonly List<HandlingEvent> _deliveryHistory = new();

    #pragma warning disable CS8618 // Required by Entity Framework
    private Cargo() { }

    internal Cargo(int customerId, DeliverySpecification deliverySpecification)
    {
        CustomerId = customerId;
        DeliveryGoal = deliverySpecification;
    }
    
    public bool IsClaimed => _deliveryHistory.Any(e => e.Type == HandlingEventType.Claim);

    public bool IsDeliveryGoalReached
    {
        get
        {
            if (_deliveryHistory.Count == 0) return false;
            var lastEvent = _deliveryHistory.Last();
            return lastEvent.Type == HandlingEventType.Claim && 
                   lastEvent.TimeStamp <= DeliveryGoal.DueDate;
        }
    }

    public IReadOnlyCollection<HandlingEvent> DeliveryHistory => _deliveryHistory.AsReadOnly();

    public void ChangeDeliveryGoal(DeliverySpecification routeSpecification)
    {
        DeliveryGoal = routeSpecification;
    }

    public void RegisterHandlingEvent(HandlingEvent handlingEvent)
    {
        if (handlingEvent.TrackingId != Id)
        {
            throw new InvalidOperationException("Handling event does not match this cargo.");
        }
        _deliveryHistory.Add(handlingEvent);
    }
}
