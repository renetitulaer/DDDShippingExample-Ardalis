using Ardalis.SharedKernel;
using Domain.Aggrgates.CargoAggregate;

namespace Application;

public class TrackingAppService
{
    private readonly IRepository<Cargo> _cargoRepository;

    public TrackingAppService(IRepository<Cargo> cargoRepository)
    {
        _cargoRepository = cargoRepository;
    }
    //public IEnumerable<HandlingEvent> GetDeliveryHistory(int trackingId)
    //{
    //        var cargo = _cargoQueryService.GetCargoByTrackingId(trackingId);
    //        return cargo.GetDeliveryHistory();
    //}
}
