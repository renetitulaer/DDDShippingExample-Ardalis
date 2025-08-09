using Ardalis.Specification;

namespace Domain.Aggrgates.CargoAggregate.Specifications;
public class CargoSpecification : Specification<Cargo>, ISingleResultSpecification<Cargo>
{
    public CargoSpecification(TrackingId trackingId)
    {
        Query.Where(c => c.Id == trackingId);
    }
}
