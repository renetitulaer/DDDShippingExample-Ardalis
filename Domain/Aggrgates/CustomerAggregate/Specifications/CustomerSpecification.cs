//using Ardalis.Specification;
using Ardalis.Specification;
using Domain.SeedWork;

namespace Domain.Aggrgates.CustomerAggregate.Specifications;
public class CustomerSpecification : CriteriaSpecification<Customer>, ISingleResultSpecification<Customer>
{
    public CustomerSpecification ByCustomerName(string customerName)
    {
        criteriaParts.Add(x => x.Name == customerName);
        return this;
    }
}
