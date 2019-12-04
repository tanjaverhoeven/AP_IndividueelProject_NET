using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class DetailLineRepository : IEnitityRepository<DetailLine>
    {
        InvoiceSystemContext context = new InvoiceSystemContext();

        public List<DetailLine> All() => context.DetailLines.ToList();

        public DetailLine FindById(int? id)
        {
            return context.DetailLines.Find(id);
        }

        public void InsertorUpdate(DetailLine invoiceDetail)
        {
            if (invoiceDetail.Id == default(int))
            {
                //new entity
                context.DetailLines.Add(invoiceDetail);
                context.SaveChanges();
            }
            else
            {
                //Existing entity
                context.Entry(invoiceDetail).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(DetailLine invoiceDetail)
        {
            context.DetailLines.Remove(invoiceDetail);
            context.SaveChanges();
        }
    }
}
