using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class UserRoleRepository : IEnitityRepository<UserRole>
    {
        InvoiceSystemContext context = new InvoiceSystemContext();

        public List<UserRole> All() => context.UsersRoles.ToList();

        public UserRole FindById(int? id)
        {
            return context.UsersRoles.Find(id);
        }

        public void InsertorUpdate(UserRole userRole)
        {
            if (userRole.Id == default(int))
            {
                //new entity
                context.UsersRoles.Add(userRole);
                context.SaveChanges();
            }
            else
            {
                //Existing entity
                context.Entry(userRole).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(UserRole userRole)
        {
            context.UsersRoles.Remove(userRole);
            context.SaveChanges();
        }
    }
}
