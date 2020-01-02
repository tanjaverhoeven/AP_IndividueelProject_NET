using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class InvoiceRepository :IEnitityRepository<Invoice>
    {
        private InvoiceSystemContext _context;

        public InvoiceRepository(InvoiceSystemContext context)
        {
            _context = context;
        }

        public List<Invoice> All() => _context.Invoices.ToList();

        public Invoice FindById(int? id)
        {
            return _context.Invoices.Find(id);
        }

        public void Update(Invoice invoice)
        {
            _context.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
        }

        public void Insert(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
        }

        public void Delete(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }
    }
}
