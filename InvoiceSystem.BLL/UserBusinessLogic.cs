using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL.Repositories;
using System.Collections.Generic;

namespace InvoiceSystem.BLL
{
    public class UserBusinessLogic
    {
        private UserRepository _userDA = new UserRepository();

        public void InsertorUpdate(User t) => _userDA.InsertorUpdate(t);

        public List<User> All() => _userDA.All();

        public void Delete(User t) => _userDA.Delete(t);

        public User FindById(int? id) => _userDA.FindById(id);
    }
}
