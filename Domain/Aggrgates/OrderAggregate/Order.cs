using Ardalis.SharedKernel;

namespace Domain.Aggrgates.OrderAggregate;
/// <summary>
/// TODO: implement Order as an aggregate root and save.
/// </summary>
internal class Order : EntityBase
{
    private readonly List<OrderLine> _items = new();
    public IReadOnlyCollection<OrderLine> Items => _items.AsReadOnly();

    public void AddOrderLine(OrderLine orderLine)
    {
        if (orderLine == null)
        {
            throw new ArgumentNullException(nameof(orderLine), "Order line cannot be null.");
        }
        
        _items.Add(orderLine);
    }
}
