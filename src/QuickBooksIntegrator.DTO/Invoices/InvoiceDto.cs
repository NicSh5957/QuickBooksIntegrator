namespace QuickBooksIntegrator.DTO.Invoices;

public class InvoiceDto
{
    public string InvoiceNumber { get; set; } 
    public string CustomerName { get; set; }
    public DateTime Date { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
}