using Application.QueryServices;
using Ardalis.SharedKernel;
using Domain;
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

        var customer = await _customerRepository.SingleOrDefaultAsync(customerSpec, cancellationToken);
        if (customer == null)
        {
            throw new ArgumentException($"Customer '{createCargoCommand.customerName}' not found.");
        }

        var destination = _locationQueryService.GetLocationById(createCargoCommand.destinationLocationId);
        
        var cargo = new CargoFactory().CreateCargo(
            customer.Id, createCargoCommand.deliveryGoal, destination.Id);

        await _cargoRepository.AddAsync(cargo);
        _unitOfWork.SaveChanges();

        return cargo;
    }
}
