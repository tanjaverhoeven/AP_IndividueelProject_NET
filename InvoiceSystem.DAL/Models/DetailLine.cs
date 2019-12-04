namespace InvoiceSystem.DAL.Models
{
    public class DetailLine
    {
        public int Id { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        public string Item { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Amount { get; set; }
        public decimal VATPercentage { get; set; }
    }
}
