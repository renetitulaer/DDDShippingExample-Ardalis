using Ardalis.SharedKernel;
using Domain.Aggrgates.CargoAggregate;
using Domain.SeedWork;

namespace Application.Booking.Commands.ChangeDestination;
public class ChangeDestinationCommandHandler
{
    private readonly IRepository<Cargo> _cargoRepository;

    public ChangeDestinationCommandHandler(IRepository<Cargo> cargoRepository)
    {
        _cargoRepository = cargoRepository;
    }

    public async Task HandleAsync(ChangeDestinationCommand changeDestinationCommand)
    {
        var cargo = await _cargoRepository.GetByIdAsync(changeDestinationCommand.TrackingId);

        if (cargo == null)
        {
            throw new ArgumentException("Cargo not found");
        }

        cargo.ChangeDeliveryGoal(new RouteSpecification(new DateTime(2025, 1, 1), 
            changeDestinationCommand.NewDestinationId));
    }
}
