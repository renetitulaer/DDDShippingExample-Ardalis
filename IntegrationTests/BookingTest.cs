using Application.Booking.Commands.ChangeDestination;
using Application.Booking.Commands.CreateCargo;
using Application.Booking.Queries.GetCargo;
using Application.CargoEventListener.Command.CargoEventReceived;
using Application.IncidentLogging.Command.CreateIncedentLogging;
using Application.QueryServices;
using Application.Voyage.Commands.CreateMovement;
using Clean.Architecture.Infrastructure.Data;
using Domain;
using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CustomerAggregate;
using Domain.Aggrgates.HandlingEventAggregate;
using Infrastructure.Persistency;
using Infrastructure.QueryServices;

namespace IntegrationTests;

public class BookingTest : ShippingTest
{
    [Test]
    public async Task CargoDelivery()
    {
        using (var shippContext = new ShippingDbContext())
        {
            var createCargoCommandhandler = new CreateCargoCommandHandler(
                new EfRepository<Cargo>(shippContext),
                new EfRepository<Customer>(shippContext),
                new EfUnitOfWork(shippContext));

            var destination = new LocationQueryService()
                .GetLocationByCity("New York");

            var cargo = await createCargoCommandhandler.HandleAsync(
                new CreateCargoCommand("Cargo Care",
                    destination.Id,
                    new DateTime(2025, 10, 1)),
                CancellationToken.None);

            // Change destination before voyage creation (otherwise a new voyage should be created)
            destination = new LocationQueryService()
                .GetLocationByCity("Berlin");

            var handler = new ChangeDestinationCommandHandler(
                new EfRepository<Cargo>(shippContext));
            await handler.HandleAsync(new ChangeDestinationCommand(cargo.Id,
                destination.Id, new DateTime(2025, 11, 1)));

            var createVoyageCommand = new CreateVoyageCommand(cargo.Id);
            var createVoyageCommandHandler = new CreateVoyageCommandHandler(createVoyageCommand);
            var voyageResponse = createVoyageCommandHandler.Handle(createVoyageCommand);

            // Simulate handling events
            var cargoEventReceivedCommandHandler = new CargoEventReceivedCommandHandler(
                new EfUnitOfWork(shippContext));

            // Load New York (1)
            var cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Load, DateTime.Now);
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);

            // Unload Rotterdam (2)
            cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Unload, DateTime.Now);
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);

            // Load Rotterdam (2)
            cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Load, DateTime.Now);
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);

            // Unload Venlo (3)
            cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Unload, DateTime.Now);
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);

            // Load Venlo (3)
            cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Load, DateTime.Now);
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);

            // Unload Berlin (4)
            cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Unload, DateTime.Now);
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);

            // Unload Berlin (4)
            cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Claim, DateTime.Now);
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);

            Assert.IsTrue(cargo.IsClaimed);
            Assert.IsTrue(cargo.IsDeliveryGoalReached);

            // Check if cargo is stored correctly
            using (var shippContext2 = new ShippingDbContext())
            {
                var cargoQuery = new GetCargoQuery(cargo.Id);
                var cargoQueryHandler = new GetCargoQueryHandler(
                    new EfRepository<Cargo>(shippContext2));
                var cargo2 = await cargoQueryHandler.HandleAsync(cargoQuery);
                if (cargo2 == null)
                {
                    Assert.Fail("Cargo not found when retrieved from storage.");
                }
                else
                {
                    Assert.IsTrue(cargo2.IsClaimed);
                    Assert.IsTrue(cargo2.IsDeliveryGoalReached);
                }
            }
        }
    }
}