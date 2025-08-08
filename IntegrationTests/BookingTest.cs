using Application.Booking.Commands.ChangeDestination;
using Application.Booking.Commands.CreateCargo;
using Application.CargoEventListener.Command.CargoEventReceived;
using Application.IncidentLogging.Command.CreateIncedentLogging;
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
                new LocationQueryService(),
                new EfUnitOfWork(shippContext));

            var cargo = await createCargoCommandhandler.HandleAsync(
                new CreateCargoCommand("Cargo Care", 
                    new LocationIdentity(1), 
                    new DateTime(2025, 10, 1)), 
                CancellationToken.None);

            var createVoyageCommand = new CreateVoyageCommand(new TrackingId(cargo.Id.Value));
            var createVoyageCommandHandler = new CreateVoyageCommandHandler();
            var voyageResponse = createVoyageCommandHandler.Handle(createVoyageCommand);

            // QUESTION: for which movement is this?
            // For now take the first one
            // What is the logic? We know the traking id of the cargo.
            // Movement has from and to location. Handling event has no location.
            // Otherwise we would know: for Load use FromLocation, for Unload use ToLocation.
            var movement = voyageResponse.CarrierMovements.First();
            
            var cargoEventReceivedCommand = new CargoEventReceivedCommand(cargo,
                HandlingEventType.Load, DateTime.Now, movement);
            var cargoEventReceivedCommandHandler = new CargoEventReceivedCommandHandler(new EfUnitOfWork(shippContext)
                //, new HandlingEventRepository(shippContext)
                );
            cargoEventReceivedCommandHandler.Handle(cargoEventReceivedCommand);
            
            // Load New York (1)
            // Unload Rotterdam (2)
            // Load Rotterdam (2)
            // Unload Venlo (3)
            // Load Venlo (3)
            // Unload Berlin (4)
            Assert.Pass();
        }
    }

    [Test]
    public async Task ChangeDestination()
    {
        using (var shippContext = new ShippingDbContext())
        {
            var handler = new ChangeDestinationCommandHandler(
                new EfRepository<Cargo>(shippContext));
            await handler.HandleAsync(new ChangeDestinationCommand(1, 1));

            Assert.Pass();
        }
    }
}