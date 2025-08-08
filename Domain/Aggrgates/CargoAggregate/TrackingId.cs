using Ardalis.SharedKernel;

namespace Domain.Aggrgates.CargoAggregate;
/// <summary>
/// TODO: use this value object.
/// </summary>
public class TrackingId : ValueObject
{
    public int Value { get; private set; }
    public TrackingId(int id)
    {
        Value = id;
    }
    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
