using Application.QueryServices;
using Ardalis.SharedKernel;
using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CustomerAggregate;
using Domain.Aggrgates.CustomerAggregate.Specifications;

namespace Application.Booking.Commands.CreateCargo;

public class CreateCargoCommandHandler
{
    private readonly IRepository<Cargo> _cargoRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly ILocationQueryService _locationQueryService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCargoCommandHandler(IRepository<Cargo> cargoRepository,
        IRepository<Customer> customerRepository,
        ILocationQueryService locationQueryService,
        IUnitOfWork unitOfWork)
    {
        _cargoRepository = cargoRepository;
        _customerRepository = customerRepository;
        _locationQueryService = locationQueryService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Cargo> HandleAsync(CreateCargoCommand createCargoCommand,
        CancellationToken cancellationToken)
    {
        // TODO: input validation/guards
        var customerSpec = new CustomerSpecification();
        customerSpec.ByCustomerName(createCargoCommand.customerName);

        var customer = await _customerRepository.ListAsync(customerSpec, cancellationToken);

        var destination = _locationQueryService.GetLocationById(createCargoCommand.destinationLocationId);
        if (destination == null)
        {                 
            throw new InvalidOperationException("Destination not found.");
        }

        // QUESTION: do we need a factory for route spec?
        // Is it an aggregate?
        var routeSpec = new RouteSpecification(new DateTime(2025, 1, 1),
                                destination.Id);

        var cargo = new CargoFactory().CreateCargo(
            customer.Select(c => c.Id).Single(),
            routeSpec);

        await _cargoRepository.AddAsync(cargo);
        _unitOfWork.SaveChanges();

        return cargo;
    }
}
