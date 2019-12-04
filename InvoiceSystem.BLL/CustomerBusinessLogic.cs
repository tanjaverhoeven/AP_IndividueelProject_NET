using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.BLL
{
    public class CustomerBusinessLogic
    {
        private readonly CustomerRepository _customerDA = new CustomerRepository();

        public List<Customer> ActiveCustomers
        {
            get
            {
                List<Customer> customers = _customerDA.All();
                customers.Where(c => c.IsActive == true).ToList();
                return customers;
            }
        }

        public void InsertorUpdate(Customer customer) => _customerDA.InsertorUpdate(customer);

        public void Delete(Customer customer) => _customerDA.Delete(customer);

        public Customer FindById(int? id) => _customerDA.FindById(id);


        public void SetInactive(int? id)
        {
            Customer customer = _customerDA.FindById(id);
            customer.IsActive = true;
            _customerDA.InsertorUpdate(customer);
        }
    }
}
