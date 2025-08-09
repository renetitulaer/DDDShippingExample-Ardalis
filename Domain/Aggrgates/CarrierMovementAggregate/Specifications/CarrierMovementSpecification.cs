using Domain.SeedWork;

namespace Domain.Aggrgates.CarrierMovementAggregate.Specifications;
public class CarrierMovementSpecification : CriteriaSpecification<CarrierMovement>
{
    public CarrierMovementSpecification ByScheduleId(int scheduleId)
    {
        criteriaParts.Add(x => x.Id == scheduleId);
        return this;
    }
}
