using Ardalis.SmartEnum;

namespace Domain.Aggrgates.HandlingEventAggregate;

public class HandlingEventType : SmartEnum<HandlingEventType>
{
    public static readonly HandlingEventType Load = new(nameof(Load), 1);
    public static readonly HandlingEventType Unload = new(nameof(Unload), 2);
    public static readonly HandlingEventType Receive = new(nameof(Receive), 3);
    public static readonly HandlingEventType Claim = new(nameof(Claim), 4);
    public static readonly HandlingEventType Customs = new(nameof(Customs), 5);
    private HandlingEventType(string name, int value) : base(name, value) { }
}
