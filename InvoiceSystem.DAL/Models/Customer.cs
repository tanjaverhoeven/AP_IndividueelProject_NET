using System.Collections.Generic;

namespace InvoiceSystem.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string Bus { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string PhoneNr { get; set; }
        public string VAT { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
