using WebApplication2.Context;
using WebApplication2.Interfaces;

namespace WebApplication2;

public class DbContextFactory : IDbContextFactory
{
    public MyDbContext CreateDbContext()
    {
        return new MyDbContext();
    }
}