using Domain;

namespace Application.QueryServices;
public interface ILocationQueryService
{
    /// <summary>
    /// Gets the location by id.
    /// </summary>
    LocationDto GetLocationById(LocationIdentity locationId);
}
