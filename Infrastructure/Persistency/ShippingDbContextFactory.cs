using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistency;

public class ShippingDbContextFactory : IDesignTimeDbContextFactory<ShippingDbContext>

{
    public ShippingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShippingDbContext>();

        if (args.Any())
            optionsBuilder.UseSqlServer(args[0]);

        return new ShippingDbContext(//optionsBuilder.Options
                                     );
    }
}
