using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Persistency;

namespace Clean.Architecture.Infrastructure.Data;

//inherit from Ardalis.Specification type
public class EfRepository<T>(ShippingDbContext dbContext) :
  RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
}
