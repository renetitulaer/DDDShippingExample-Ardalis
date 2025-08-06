using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CustomerAggregate;
using Domain.Aggrgates.HandlingEventAggregate;
using Domain.Aggrgates.LocationAggregate;
using Infrastructure.Persistency;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests;

public class ShippingTest
{
    protected Cargo Cargo { get; set; } = null!;

    [SetUp]
    public void SetUp()
    {
        CleanUp();
        Arrange();
    }

    /// <summary>
    /// TODO: this is not using DDD. Is this allowed? Refactor?
    /// </summary>
    private void Arrange()
    {
        // Arrange
        using (var shippContext = new ShippingDbContext())
        {
            var customer = new CustomerFactory().CreateCustomer("Cargo Care");
            shippContext.Customers.Add(customer);
            shippContext.SaveChanges();

            var location = new Location("VenloB2");
            shippContext.Locations.Add(location);
            shippContext.SaveChanges();

            //Cargo = new CargoFactory()
            //    .CreateCargo(customer.CustomerId, 
            //    new RouteSpecification(new DateTime(2025,1, 1), location.LocationId));
            //shippContext.Cargos.Add(Cargo);
            //shippContext.SaveChanges();
        }
    }

    public void CleanUp()
    {
        // Clean up the database
        using (var shippContext = new ShippingDbContext())
        {
            shippContext.Database.ExecuteSql($"delete from Customers");
            shippContext.Database.ExecuteSql($"delete from Cargos");
            shippContext.Database.ExecuteSql($"delete from CarrierMovements");
            shippContext.Database.ExecuteSql($"delete from Locations");
            shippContext.Database.ExecuteSql($"delete from HandlingEvents");

        }
    }
}
