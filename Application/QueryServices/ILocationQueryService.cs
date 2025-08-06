using Domain.Aggrgates.LocationAggregate;

namespace Application.QueryServices;
public interface ILocationQueryService
{
    /// <summary>
    /// Gets the location by id.
    /// NOTE: this is an example of an external service. For now it's still the database
    /// but it could be anythinng. The location is defined in application layer. It's not part of our domain.
    /// </summary>
    Location? GetLocationById(int locationId);
}
