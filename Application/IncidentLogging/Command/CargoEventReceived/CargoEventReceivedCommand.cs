using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CarrierMovementAggregate;
using Domain.Aggrgates.HandlingEventAggregate;

namespace Application.CargoEventListener.Command.CargoEventReceived;
public class CargoEventReceivedCommand(Cargo cargo, HandlingEventType handllingType, DateTime timeStamp)
{
    public Cargo Cargo { get; set; } = cargo;
    public HandlingEventType HandlingType { get; set; } = handllingType ?? throw new ArgumentNullException(nameof(handllingType));
    public DateTime TimeStamp { get; set; } = timeStamp;
}
