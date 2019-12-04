using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class InvoiceRepository :IEnitityRepository<Invoice>
    {
        InvoiceSystemContext context = new InvoiceSystemContext();

        public List<Invoice> All() => context.Invoices.ToList();

        public Invoice FindById(int? id)
        {
            return context.Invoices.Find(id);
        }

        public void InsertorUpdate(Invoice invoice)
        {
            if (invoice.Id == default(int))
            {
                //new entity
                invoice.IsActive = true;
                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
            else
            {
                //Existing entity
                context.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Invoice invoice)
        {
            context.Invoices.Remove(invoice);
            context.SaveChanges();
        }
    }
}
