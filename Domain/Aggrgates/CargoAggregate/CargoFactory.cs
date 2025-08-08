namespace Domain.Aggrgates.CargoAggregate;

public class CargoFactory()
{
    public Cargo CreateCargo(int customerId, DateTime arrivalDate, LocationIdentity destination)
    {
        var deliveryGoal = new DeliverySpecification(arrivalDate, destination);
        var cargo = new Cargo(customerId, deliveryGoal);
        return cargo;
    }
}
