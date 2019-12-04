using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL.Repositories;
using System.Collections.Generic;

namespace InvoiceSystem.BLL
{
    public class RoleBusinessLogic
    {
        private RoleRepository _roleDA = new RoleRepository();

        public void InsertorUpdate(Roling t) => _roleDA.InsertorUpdate(t);

        public List<Roling> All() => _roleDA.All();

        public void Delete(Roling t) => _roleDA.Delete(t);

        public Roling FindById(int? id) => _roleDA.FindById(id);
    }
}
