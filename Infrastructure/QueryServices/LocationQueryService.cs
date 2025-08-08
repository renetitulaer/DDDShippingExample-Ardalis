using Application.QueryServices;
using Domain;
using Infrastructure.Persistency;

namespace Infrastructure.QueryServices;
public class LocationQueryService : ILocationQueryService
{
    private IEnumerable<LocationDto> _locations => new List<LocationDto>
    {
        new LocationDto(new LocationIdentity(1), "New York" ),
        new LocationDto(new LocationIdentity(2), "Rotterdam" ),
        new LocationDto(new LocationIdentity(3), "Venlo" ),
        new LocationDto(new LocationIdentity(4), "Berlin" ),
    };

    public LocationDto GetLocationById(LocationIdentity locationId)
    {
        return _locations.Single(l => l.Id == locationId);
    }

    public LocationDto GetCity(string city)
    {
        return _locations.Single(l => l.City == city);
    }
}
