using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrator.Infrastructure.Services;

namespace QuickBooksIntegrator.Web.Controllers;

public class BillController : Controller
{
    private readonly BillService _billService;

    public BillController(BillService billService) => _billService = billService;

    public async Task<IActionResult> Index()
    {
        try
        {
            var bills = await _billService.GetBillDataAsync();
            return View(bills);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Error retrieving bills: {ex.JoinInnerExceptions()}";
            return View("Error");
        }
    }
}