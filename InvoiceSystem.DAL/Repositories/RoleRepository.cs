using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceSystem.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InvoiceSystem.DAL.Repositories
{
    public class RoleRepository : IEnitityRepository<IdentityRole>
    {
        private RoleManager<IdentityRole> _roleManager;
        private InvoiceSystemContext _context = new InvoiceSystemContext();

        public RoleRepository()
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
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

        public IdentityRole FindById(int? id)
        {
            throw new NotImplementedException();
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
