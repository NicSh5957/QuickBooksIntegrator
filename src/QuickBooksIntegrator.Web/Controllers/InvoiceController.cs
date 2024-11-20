using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrator.DTO.Invoices;
using QuickBooksIntegrator.Infrastructure.Services;

namespace QuickBooksIntegrator.Web.Controllers;

public class InvoiceController : Controller
{
    private readonly InvoiceService _invoiceService;

    public InvoiceController(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var invoices = await _invoiceService.GetInvoiceDataAsync();
            return View(invoices);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Error retrieving invoices: {ex.JoinInnerExceptions()}";
            return View("Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(string customerName, DateTime date, string itemName, int quantity, decimal rate)
    {
        if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(itemName) || quantity <= 0 || rate <= 0)
        {
            ViewBag.Error = "All fields are required and must be valid.";
            return View();
        }

        try
        { 
            await _invoiceService.AddInvoiceAsync(new InvoiceDto() {CustomerName = customerName, Date = date, ItemName = itemName, Quantity = quantity, Amount = rate});
            ViewBag.Message = $"Invoice created successfully.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Error creating invoice: {ex.JoinInnerExceptions()}";
            return View("Error");
        }
    }

    [HttpGet]
    public IActionResult Create() => View();
}