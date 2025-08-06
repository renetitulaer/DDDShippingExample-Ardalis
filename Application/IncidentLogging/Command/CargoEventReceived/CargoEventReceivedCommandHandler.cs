using Application.CargoEventListener.Command.CargoEventReceived;
using Domain.Aggrgates.HandlingEventAggregate;
using Domain.SeedWork;

namespace Application.IncidentLogging.Command.CreateIncedentLogging;
public class CargoEventReceivedCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly IRepository<HandlingEvent> _handlingEventRepository;

    public CargoEventReceivedCommandHandler(IUnitOfWork unitOfWork
        //, IRepository<HandlingEvent> handlingEventRepository
        )
    {
        _unitOfWork = unitOfWork;
        //_handlingEventRepository = handlingEventRepository;
    }
    public void Handle(CargoEventReceivedCommand cargoEventReceivedCommand)
    {
        // Load New York
        var handlingEvent = new HandlingEventFactory().CreateHandlingEvent(
            cargoEventReceivedCommand.Cargo.Id,
            cargoEventReceivedCommand.TimeStamp,
            ConvertInputToHandlingTypeEnum(cargoEventReceivedCommand.HandlingType));
        
        cargoEventReceivedCommand.Cargo.RegisterHandlingEvent(handlingEvent);
        _unitOfWork.SaveChanges();
    }

    /// <summary>
    /// TODO: smart enum.
    /// </summary>
    /// <param name="handlingType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private HandlingEventType ConvertInputToHandlingTypeEnum(string handlingType)
    {
        if (handlingType == "Loaded")
        {
            return HandlingEventType.Load;
        }
        else
        {
            throw new ArgumentException($"Unknown handling type: {handlingType}");
        }
    }
}
