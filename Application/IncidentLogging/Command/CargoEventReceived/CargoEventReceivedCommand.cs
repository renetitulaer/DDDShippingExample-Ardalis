using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CarrierMovementAggregate;

namespace Application.CargoEventListener.Command.CargoEventReceived;
public class CargoEventReceivedCommand(Cargo cargo, string handllingType, DateTime timeStamp, Domain.Aggrgates.CarrierMovementAggregate.CarrierMovement movement)
{
    public Cargo Cargo { get; set; } = cargo;
    public string HandlingType { get; set; } = handllingType ?? throw new ArgumentNullException(nameof(handllingType));
    public DateTime TimeStamp { get; set; } = timeStamp;
    public CarrierMovement CarrierMovement { get; } = movement;
}
