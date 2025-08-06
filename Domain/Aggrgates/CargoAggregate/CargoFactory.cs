namespace Domain.Aggrgates.CargoAggregate
{
    public class CargoFactory(//IShippingDbContext shippingDbContext
                              )
    {
        //private readonly IShippingDbContext shippingDbContext = shippingDbContext;

        public Cargo CreateCargo(int customerId, RouteSpecification deliveryGoal)
        {
            var cargo = new Cargo(customerId, deliveryGoal);
            return cargo;
        }
    }
}
