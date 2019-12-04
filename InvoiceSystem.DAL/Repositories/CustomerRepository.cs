using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class CustomerRepository : IEnitityRepository<Customer>
    {
        InvoiceSystemContext context = new InvoiceSystemContext();

        public List<Customer> All() => context.Costumers.ToList();

        public void Delete(Customer customer)
        { 
            context.Costumers.Remove(customer);
            context.SaveChanges();
        }

        public Customer FindById(int? id)
        {
            return context.Costumers.Find(id);
        }

        public void InsertorUpdate(Customer customer)
        {
            if (customer.Id == default(int))
            {
                //new entity
                context.Costumers.Add(customer);
                context.SaveChanges();
            }
            else
            {
                //Existing entity
                context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
