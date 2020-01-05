using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceSystem.DAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InvoiceSystem.BLL
{
    public class RoleBusinessLogic
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleBusinessLogic(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public List<IdentityRole> All()
        {
            return _roleManager.Roles.ToList();
        }

        public void Delete(IdentityRole t)
        {
            _roleManager.Delete(t);
        }

        public IdentityRole FindById(string id)
        {
            return _roleManager.FindById(id);
        }

        public void Insert(IdentityRole t)
        {
            _roleManager.Create(t);
        }

        public void Update(IdentityRole t)
        {
            _roleManager.Update(t);
        }

    }
}
