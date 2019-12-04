using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.BLL
{
    public class DetailLineBusinessLogic
    {
        private DetailLineRepository _detailLineDA = new DetailLineRepository();

        public void CreaInsertorUpdatete(DetailLine detailLine) => _detailLineDA.InsertorUpdate(detailLine);

        public void Delete(DetailLine detailLine) => _detailLineDA.Delete(detailLine);

        public DetailLine FindById(int? id) => _detailLineDA.FindById(id);

        public List<DetailLine> GetAll() => _detailLineDA.All();

        public List<DetailLine> FindByInvoice(Invoice invoice) => _detailLineDA.All().Where(i => i.Invoice == invoice).ToList();
    }
}
