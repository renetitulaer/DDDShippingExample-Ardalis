using Application;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistency;
public class EfUnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;

    public EfUnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveChanges()
        => _dbContext.SaveChanges();
}

