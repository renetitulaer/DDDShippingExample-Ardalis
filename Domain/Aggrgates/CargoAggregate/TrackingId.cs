using Ardalis.SharedKernel;
using Domain.SeedWork;

namespace Domain.Aggrgates.CargoAggregate;
/// <summary>
/// TODO: use this value object.
/// </summary>
public class TrackingId : ValueObject
{
    public int Id { get; private set; }
    public TrackingId(int id)
    {
        Id = id;
    }
    public override string ToString()
    {
        return Id.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
