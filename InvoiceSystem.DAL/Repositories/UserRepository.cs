using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class UserRepository : IEnitityRepository<User>
    {
        InvoiceSystemContext context = new InvoiceSystemContext();

        public List<User> All() => context.Users.ToList();

        public User FindById(int? id)
        {
            return context.Users.Find(id);
        }

        public void InsertorUpdate(User user)
        {
            if (user.IdU == default(int))
            {
                //new entity
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                //Existing entity
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
