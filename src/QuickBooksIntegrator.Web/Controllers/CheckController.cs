using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrator.Infrastructure.Services;

namespace QuickBooksIntegrator.Web.Controllers;

public class CheckController : Controller
{
    private readonly CheckService _checkService;

    public CheckController(CheckService checkService) => _checkService = checkService;

    public async Task<IActionResult> Index()
    {
        try
        {
            var checks = await _checkService.GetCheckDataAsync();
            return View(checks);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Error retrieving checks: {ex.JoinInnerExceptions()}";
            return View("Error");
        }
    }
}