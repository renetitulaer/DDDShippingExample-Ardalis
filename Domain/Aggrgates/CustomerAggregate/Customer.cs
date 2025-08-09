using Ardalis.SharedKernel;

namespace Domain.Aggrgates.CustomerAggregate;

public class Customer : EntityBase, IAggregateRoot 
{
    public string Name { get; private set; }

    //#pragma warning disable CS8618 // Required by Entity Framework
    // The default constructor is commented out, EF will use the internal constructor
    // because of constructor binding: then name paramater matches the property name.
    //private Customer() {}

    internal Customer(string name)
    {
        Name = name;
    }    
    
    public void ChangeName(string name)
    {
        Name = name;
    }
}
