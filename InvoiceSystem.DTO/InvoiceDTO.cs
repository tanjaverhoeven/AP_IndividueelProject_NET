using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public CustomerDTO Customer { get; set; }
        public int CustumorId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Code { get; set; }
        public bool State { get; set; }
        public bool IsActive { get; set; }
        public string Reason { get; set; }
        public ICollection<DetailLineDTO> DetailLines { get; set; }
    }
}
