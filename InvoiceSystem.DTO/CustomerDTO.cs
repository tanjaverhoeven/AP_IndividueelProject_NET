using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string Bus { get; set; }
        public CityDTO City { get; set; }
        public int CityId { get; set; }
        public string PhoneNr { get; set; }
        public string VAT { get; set; }
        public ICollection<InvoiceDTO> Invoices { get; set; }
    }
}
