using WebApplication2.Models;

namespace WebApplication2.Interfaces;

public interface ISalesOrderRepository
{
    Task<decimal?> GetRevenueByCountry(string countryName);
    Task<decimal?> GetRevenueByItemType(string itemType);
    Task<int> CountryCount();
    Task<List<ItemRevenueDto>> GetAllItemRevenue();
    Task<List<ItemRevenueDto>> GetAllCountryRevenue();
}