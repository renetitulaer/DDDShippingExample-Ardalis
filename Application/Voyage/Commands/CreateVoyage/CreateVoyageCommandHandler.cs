using Application.Voyage.Commands.CreateVoyage;
using Domain;
using Domain.Aggrgates.CarrierMovementAggregate;
using Domain.Aggrgates.HandlingEventAggregate;

namespace Application.Voyage.Commands.CreateMovement;
public class CreateVoyageCommandHandler
{
    private CreateVoyageCommand _createVoyageCommand;

    public CreateVoyageCommandHandler(CreateVoyageCommand createVoyageCommand)
    {
        _createVoyageCommand = createVoyageCommand;
    }

    public VoyageResponse Handle(CreateVoyageCommand createVoyageCommand)
    {
        List<CarrierMovement> carrierMovements = new List<CarrierMovement>()
        {
            new CarrierMovementFactory().CreateCarrierMovement(1, new LocationIdentity(1), new LocationIdentity(2)), // New York -> Rotterdam
            new CarrierMovementFactory().CreateCarrierMovement(2, new LocationIdentity(2), new LocationIdentity(3)), // Rotterdam -> Venlo
            new CarrierMovementFactory().CreateCarrierMovement(3, new LocationIdentity(3), new LocationIdentity(4))  // Venlo -> Berlin
        };

        return new VoyageResponse(carrierMovements);
    }
}
