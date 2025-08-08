using Ardalis.SharedKernel;
using Domain.Aggrgates.HandlingEventAggregate;

namespace Domain.Aggrgates.CargoAggregate;

public class Cargo : EntityBase<Cargo, TrackingId>, IAggregateRoot 
{
    public int CustomerId { get; private set; }

    public DeliverySpecification RouteSpecification { get; private set; }

    private readonly List<HandlingEvent> _deliveryHistory = new();

    /* This constructor is used by EF Core while
       getting the entity from database */
    private Cargo() { }

    internal Cargo(int customerId, DeliverySpecification routeSpecification)
    {
        CustomerId = customerId;
        RouteSpecification = routeSpecification;
    }
    
    public IReadOnlyCollection<HandlingEvent> DeliveryHistory => _deliveryHistory.AsReadOnly();

    public void ChangeDeliveryGoal(DeliverySpecification routeSpecification)
    {
        RouteSpecification = routeSpecification;
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
