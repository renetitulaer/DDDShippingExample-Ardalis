using Application.QueryServices;
using Domain.Aggrgates.CargoAggregate;
using Domain.Aggrgates.CarrierMovementAggregate;
using Domain.Aggrgates.CustomerAggregate;
using Domain.Aggrgates.HandlingEventAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistency
{
    public class ShippingDbContext : DbContext//, IShippingDbContext
    {
        public ShippingDbContext(//DbContextOptions<ShippingDbContext> options
                                 )
        : base(//options
               )
        {
        }

        /// <summary>
        /// TODO: configure the database connection
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local)\\sql2022;Database=DDDShippingExample;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Application Name=DDDShippingExample");

            //optionsBuilder.AddInterceptors(new ShippingCommandInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShippingDbContext).Assembly);
        }

        public DbSet<Cargo> Cargos => Set<Cargo>();

        public DbSet<CarrierMovement> CarrierMovements => Set<CarrierMovement>();

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<HandlingEvent> HandlingEvents => Set<HandlingEvent>();

        //public DbSet<Location> Locations => Set<Location>();        
    }
}
