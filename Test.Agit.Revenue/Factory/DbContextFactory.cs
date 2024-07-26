using WebApplication2.Context;
using WebApplication2.Interfaces;

namespace WebApplication2;

public class DbContextFactory : IDbContextFactory
{
    private readonly string _connectionString;
    public DbContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    public MyDbContext CreateDbContext()
    {
        return new MyDbContext(_connectionString);
    }
}