namespace QuickBooksIntegrator.DTO.Bills;

public class BillDto
{
    public string BillNumber { get; set; }
    public DateTime Date { get; set; }
    public decimal AmountDue { get; set; }
}