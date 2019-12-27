using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class CustomerRepository : IEnitityRepository<Customer>
    {
        private InvoiceSystemContext _context;

        public CustomerRepository(InvoiceSystemContext context)
        {
            _context = context;
        }

        public List<Customer> All() => _context.Costumers.ToList();

        public void Delete(Customer customer)
        { 
            _context.Costumers.Remove(customer);
        }

        public Customer FindById(int? id)
        {
            return _context.Costumers.Find(id);
        }

        public void InsertorUpdate(Customer customer)
        {
            if (customer.Id == default(int))
            {
                //new entity
                customer.IsActive = true;
                _context.Costumers.Add(customer);
            }
            else
            {
                //Existing entity
                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
