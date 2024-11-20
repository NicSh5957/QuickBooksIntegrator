using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrator.Infrastructure.Services;

namespace QuickBooksIntegrator.Web.Controllers;

public class ItemSalesController : Controller
{
    private readonly ItemSalesService _itemSalesService;

    public ItemSalesController(ItemSalesService itemSalesService) => _itemSalesService = itemSalesService;

    public async Task<IActionResult> Index()
    {
        try
        {
            var itemSales = await _itemSalesService.GetItemSalesDataAsync();
            return View(itemSales);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Error retrieving item sales data: {ex.JoinInnerExceptions()}";
            return View("Error");
        }
    }
}