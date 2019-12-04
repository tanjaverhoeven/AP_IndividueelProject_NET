using System;
using System.Collections.Generic;

namespace InvoiceSystem.DAL.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustumorId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Code { get; set; }
        public bool State { get; set; }
        public bool IsActive { get; set; }
        public string Reason { get; set; }
        public ICollection<DetailLine> DetailLines { get; set; }
    }
}
