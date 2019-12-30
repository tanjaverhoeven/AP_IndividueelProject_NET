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

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
        }

        public void Insert(Customer customer)
        {
            customer.IsActive = true;
            _context.Costumers.Add(customer);
        }
    }
}
