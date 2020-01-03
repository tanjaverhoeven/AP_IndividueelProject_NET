using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceSystem.DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InvoiceSystem.BLL
{
    public class RoleBusinessLogic
    {
        private RoleRepository _roleRepo;

        public RoleBusinessLogic()
        {
            _roleRepo = new RoleRepository();
        }

        public List<IdentityRole> GetAll()
        {
            return _roleRepo.All();
        }

        public void Delete(IdentityRole t)
        {
            _roleRepo.Delete(t);
        }

        public IdentityRole FindById(string id)
        {
            return _roleRepo.FindById(id);
        }

        public void Insert(IdentityRole t)
        {
            _roleRepo.Insert(t);
        }

        public void Update(IdentityRole t)
        {
            _roleRepo.Update(t);
        }

    }
}
