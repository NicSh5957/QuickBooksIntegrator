using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrator.Infrastructure.Services;

namespace QuickBooksIntegrator.Web.Controllers;

public class CompanyController : Controller
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService) => _companyService = companyService;

    public async Task<IActionResult> Index()
    {
        try
        {
            var companyData = await _companyService.GetCompanyDataAsync();
            return View(companyData);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Error retrieving company data: {ex.JoinInnerExceptions()}";
            return View("Error");
        }
    }
}