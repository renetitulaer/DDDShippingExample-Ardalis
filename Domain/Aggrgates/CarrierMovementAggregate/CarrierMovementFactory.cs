using Domain.Aggrgates.CarrierMovementAggregate;

namespace Domain.Aggrgates.HandlingEventAggregate;
public class CarrierMovementFactory
{
    public CarrierMovement CreateCarrierMovement(
        int scheduleId,
        LocationIdentity fromLocationId,
        LocationIdentity toLocationId)
    {
        var carrieMovement = new CarrierMovement(
            scheduleId,
            fromLocationId,
            toLocationId);
        return carrieMovement;
    }
}
