using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class DetailLineRepository : IEnitityRepository<DetailLine>
    {
        private InvoiceSystemContext _context;

        public DetailLineRepository(InvoiceSystemContext context)
        {
            _context = context;
        }
        public List<DetailLine> All() => _context.DetailLines.ToList();

        public DetailLine FindById(int? id)
        {
            return _context.DetailLines.Find(id);
        }

        public void Update(DetailLine invoiceDetail)
        {
            _context.Entry(invoiceDetail).State = System.Data.Entity.EntityState.Modified;
        }

        public void Insert(DetailLine invoiceDetail)
        {
            _context.DetailLines.Add(invoiceDetail);
        }

        public void Delete(DetailLine invoiceDetail)
        {
            _context.DetailLines.Remove(invoiceDetail);
        }
    }
}
