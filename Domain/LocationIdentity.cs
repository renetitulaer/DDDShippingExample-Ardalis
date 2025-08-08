using Ardalis.SharedKernel;

namespace Domain;

/// <summary>
/// Represents a location identity.
/// </summary>
/// <param name="locationId"></param>
public class LocationIdentity(int locationId) : ValueObject
{
    public int Value { get; private set; } = locationId;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
