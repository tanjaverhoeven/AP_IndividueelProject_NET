using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class RoleRepository : IEnitityRepository<Roling>
    {
        InvoiceSystemContext context = new InvoiceSystemContext();

        public List<Roling> All() => context.Roles.ToList();

        public Roling FindById(int? id)
        {
            return context.Roles.Find(id);
        }

        public void InsertorUpdate(Roling role)
        {
            if (role.Id == default(int))
            {
                //new entity
                context.Roles.Add(role);
                context.SaveChanges();
            }
            else
            {
                //Existing entity
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Roling role)
        {
            context.Roles.Remove(role);
            context.SaveChanges();
        }
    }
}
