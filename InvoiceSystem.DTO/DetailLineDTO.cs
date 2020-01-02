using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.DTO
{
    public class DetailLineDTO
    {
        public int Id { get; set; }
        public InvoiceDTO Invoice { get; set; }
        public int InvoiceId { get; set; }
        public string Item { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Amount { get; set; }
        public decimal VATPercentage { get; set; }
    }
}
