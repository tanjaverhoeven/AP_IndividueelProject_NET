using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceSystem.DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InvoiceSystem.BLL
{
    public class UserBusinessLogic
    {
        private UserRepository _userRepo;

        public UserBusinessLogic()
        {
            _userRepo = new UserRepository();
        }

        public List<IdentityUser> GetAll()
        {
            return _userRepo.All();
        }

        public void Delete(IdentityUser t)
        {
            _userRepo.Delete(t);
        }

        public IdentityUser FindById(string id)
        {
            return _userRepo.FindById(id);
        }

        public void Insert(IdentityUser t)
        {
            _userRepo.Insert(t);
        }

        public void Update(IdentityUser t)
        {
            _userRepo.Update(t);
        }
    }
}
