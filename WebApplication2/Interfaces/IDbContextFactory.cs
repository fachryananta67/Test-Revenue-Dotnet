using WebApplication2.Context;

namespace WebApplication2.Interfaces;

public interface IDbContextFactory
{
    MyDbContext CreateDbContext();
}