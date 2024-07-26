using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Interfaces;
using WebApplication2.Migrations;
using WebApplication2.Models;

namespace WebApplication2.Repository;

public class SalesOrderRepository : ISalesOrderRepository
{
    private readonly IDbContextFactory _dbContextFactory;
    
    public SalesOrderRepository( IDbContextFactory dbContextFactory )
    {
        _dbContextFactory = dbContextFactory;
    }
    
    public async Task<List<ItemRevenueDto>> GetAllItemRevenue()
    {
        await using var context = _dbContextFactory.CreateDbContext();;
        
        return await context.Salesorders
            .GroupBy(s => s.ItemType)
            .Select(s => new ItemRevenueDto()
            {
                ItemName = s.Key,
                Revenue = s.Sum(x => (x.UnitPrice * x.UnitsSold) - x.UnitCost)
            })
            .ToListAsync();
    }
    
    public async Task<List<ItemRevenueDto>> GetAllCountryRevenue()
    {
        await using var context = _dbContextFactory.CreateDbContext();;
        
        return await context.Salesorders
            .GroupBy(s => s.Country)
            .Select(s => new ItemRevenueDto()
            {
                ItemName = s.Key,
                Revenue = s.Sum(x => (x.UnitPrice * x.UnitsSold) - x.UnitCost)
            })
            .ToListAsync();
    } 
    
    private decimal? CalculateRevenue(decimal? unitPrice, decimal? unitsSold, decimal? unitCost)
    {
        return (unitPrice * unitsSold) - unitCost;
    }
    
    public async Task<decimal?> GetRevenueByCountry(string countryName)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        
        var salesOrders = context.Salesorders.Where(s => s.Country == countryName)
            .ToList();

        decimal? total = 0;
        foreach (var so in salesOrders)
        {
            total += (so.UnitPrice * so.UnitsSold) - so.UnitCost;
        }
        
        return total;
    }
    
    public async Task<decimal?> GetRevenueByItemType(string itemType)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        
        var salesOrders = context.Salesorders.Where(s => s.ItemType == itemType)
            .ToList();

        decimal? total = 0;
        foreach (var so in salesOrders)
        {
            total += (so.UnitPrice * so.UnitsSold) - so.UnitCost;
        }
        
        return total;
    }
    
    public async Task<int> CountryCount()
    {
        await using var context = _dbContextFactory.CreateDbContext();
        return context.Salesorders.Select(s => s.Country).Distinct().Count();
    }
}