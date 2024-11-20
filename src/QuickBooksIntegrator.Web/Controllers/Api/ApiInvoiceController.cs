using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrator.Infrastructure.Services;
using QuickBooksIntegrator.DTO.Invoices;

namespace QuickBooksIntegrator.Web.Controllers.Api
{
    [Route("api/invoices")]
    [ApiController]
    public class ApiInvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public ApiInvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            try
            {
                var invoices = await _invoiceService.GetInvoiceDataAsync();
                if (invoices == null || !invoices.Any())
					return NotFound("No invoices found.");
				return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving invoices: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceDto invoice)
        {
            if (invoice == null || string.IsNullOrWhiteSpace(invoice.CustomerName) ||
                string.IsNullOrWhiteSpace(invoice.ItemName) || invoice.Quantity <= 0 || invoice.Amount <= 0)
				return BadRequest("Invalid invoice data.");

			try
            {
                await _invoiceService.AddInvoiceAsync(invoice);
                return Ok("Invoice created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating invoice: {ex.Message}");
            }
        }
    }
}