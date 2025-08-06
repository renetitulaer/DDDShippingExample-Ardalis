using Domain.Aggrgates.CarrierMovementAggregate;

namespace Application.Voyage.Commands.CreateVoyage;
public class VoyageResponse
{
    public IEnumerable<CarrierMovement> CarrierMovements { get; init; }
    public VoyageResponse(IEnumerable<CarrierMovement> carrierMovements)
    {
        CarrierMovements = carrierMovements;
    }
}
