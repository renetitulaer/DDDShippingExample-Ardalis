using Application.QueryServices;
using Domain.Aggrgates.LocationAggregate;
using Infrastructure.Persistency;

namespace Infrastructure.QueryServices;
public class LocationQueryService : ILocationQueryService
{
    private readonly ShippingDbContext _shippingDbContext;

    public LocationQueryService(ShippingDbContext shippingDbContext)
    {
        _shippingDbContext = shippingDbContext;
    }

    public Location? GetLocationById(int locationId)
    {
        // TODO: make an id which makes sense for the domain
        //return _shippingDbContext.Locations.Single(l => l.LocationId == locationId);
        return _shippingDbContext.Locations.First();
    }
}
