namespace Domain.Aggrgates.CustomerAggregate;

public class CustomerFactory
{
    public Customer CreateCustomer(string name)
    {
        var customer = new Customer(name);
        return customer;
    }
}
