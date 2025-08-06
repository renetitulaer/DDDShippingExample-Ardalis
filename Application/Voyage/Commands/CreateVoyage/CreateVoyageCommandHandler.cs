using Application.Voyage.Commands.CreateVoyage;
using Domain.Aggrgates.CarrierMovementAggregate;
using Domain.Aggrgates.HandlingEventAggregate;

namespace Application.Voyage.Commands.CreateMovement;
public class CreateVoyageCommandHandler
{    
    public VoyageResponse Handle(CreateVoyageCommand createVoyageCommand)
    {
        List<CarrierMovement> carrierMovements = new List<CarrierMovement>()
        {
            new CarrierMovementFactory().CreateCarrierMovement(1, 1, 2),
            new CarrierMovementFactory().CreateCarrierMovement(2, 2, 3),
            new CarrierMovementFactory().CreateCarrierMovement(3, 3, 4),
            new CarrierMovementFactory().CreateCarrierMovement(4, 4, 5),
        };

        return new VoyageResponse(carrierMovements);
    }
}
