using Domain;

namespace Application.QueryServices;

public record LocationDto
{
    /*
     *  From the blue book:
        Location -> Two places with the same name are not the same. Latitude and longitude could
        provide a unique key, but probably not a very practical one, since it is not of interest to
        most purposes of this system, and would be fairly complicated. More likely, the Location
        will be part of a geographical model of some kind that will relate places, and an arbitrary,
        internal, automatically generated identifier will suffice 

        My design choice: location is part of another bounded context. In the blue book
        the repository only has find methods so this bounded context does not maintain it.
        We can use the "Open Host Service" pattern to access it. 
        For now, the implementation is hard coded but it could be an API or a queue.
    
        So the maintenance of Location is the responsibility of another bounded context. 
        In our context we only reference it and it's a reference withing the domain.
        So we need to have a reference to it by using a value object as an identity: LocationIdentity.

        The service will return a DTO which is not part of our domain model (it's defined in the app layer).
    */
    public LocationIdentity Id { get; private set; }

    public string City { get; private set; }

    public LocationDto(LocationIdentity locationIdentity, string portCode)
    {
        Id = locationIdentity;
        City = portCode ?? throw new ArgumentNullException(nameof(portCode), "Port code cannot be null");
    }
}
