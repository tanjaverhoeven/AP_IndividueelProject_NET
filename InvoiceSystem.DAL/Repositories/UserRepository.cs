using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.DAL.Repositories
{
    public class UserRepository: IEnitityRepository<IdentityUser>
    {
        private UserManager<IdentityUser> _userManager;
        private InvoiceSystemContext _context = new InvoiceSystemContext();

        public UserRepository()
        {
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
        }

        public List<IdentityUser> All()
        {
            return _userManager.Users.ToList();
        }

        public void Delete(IdentityUser t)
        {
            _userManager.Delete(t);
        }

        public IdentityUser FindById(string id)
        {
            return _userManager.FindById(id);
        }

        public IdentityUser FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(IdentityUser t)
        {
            _userManager.Create(t);
        }

        public void Update(IdentityUser t)
        {
            _userManager.Update(t);
        }
    }
}
