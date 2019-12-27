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

        public void InsertorUpdate(Invoice invoice)
        {
            if (invoice.Id == default(int))
            {
                //new entity
                invoice.IsActive = true;
                _context.Invoices.Add(invoice);
            }
            else
            {
                //Existing entity
                _context.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }
    }
}
