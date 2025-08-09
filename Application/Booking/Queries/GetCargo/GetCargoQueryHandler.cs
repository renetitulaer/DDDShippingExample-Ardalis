using Ardalis.SharedKernel;
using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CargoAggregate.Specifications;

namespace Application.Booking.Queries.GetCargo;
public class GetCargoQueryHandler
{
    private readonly IRepository<Cargo> _cargoRepository;

    public GetCargoQueryHandler(IRepository<Cargo> cargoRepository)
    {
        _cargoRepository = cargoRepository;
    }

    public async Task<Cargo?> HandleAsync(GetCargoQuery getCargoQuery)
    {
        return await _cargoRepository
            .SingleOrDefaultAsync(new CargoSpecification(getCargoQuery.TrackingId), 
                CancellationToken.None);
    }
}
