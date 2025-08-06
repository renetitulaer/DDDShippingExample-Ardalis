using Domain.Aggrgates.CarrierMovementAggregate;

namespace Domain.Aggrgates.HandlingEventAggregate;
public class CarrierMovementFactory
{
    public CarrierMovement CreateCarrierMovement(
        int scheduleId,
        int fromLocationId,
        int toLocationId)
    {
        var carrieMovement = new CarrierMovement(
            scheduleId,
            fromLocationId,
            toLocationId);
        return carrieMovement;
    }
}
