using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interfaces;

namespace WebApplication2.Controllers;

public class SalesController : Controller
{
    private readonly ILogger<SalesController> _logger;
    private readonly ISalesOrderRepository _salesOrderRepository;

    public SalesController(ILogger<SalesController> logger, ISalesOrderRepository salesOrderRepository )
    {
        _logger = logger;
        _salesOrderRepository = salesOrderRepository;
    }
    
    public async Task<ViewResult> RevenueByItem()
    {
        var itemRevenue = await _salesOrderRepository.GetAllItemRevenue(); 
        
        return View(itemRevenue);
    }
    
    public async Task<ViewResult> RevenueByCountry()
    {
        var countryRevenue = await _salesOrderRepository.GetAllCountryRevenue(); 
        
        return View(countryRevenue);
    }
}