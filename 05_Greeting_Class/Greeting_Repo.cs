using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting_Class
{
    public class Greeting_Repo
    {
        private readonly List<Customer> _custList = new List<Customer>();
        private Customer _customer;
        public bool AddCustomer(Customer customer)
        {
                int count = _custList.Count();
                _custList.Add(customer);
                bool added = (_custList.Count > count) ? true : false;
                return added;
        }
        public List<Customer> GetCustomers()
        {
            return _custList.ToList();
        }
        public Customer UpdateCustomer(Customer customer)
        {
            _customer.FirstName = customer.FirstName;
            _customer.LastName = customer.LastName;
            _customer.Type = customer.Type;
            return customer;
        }
        public Customer GetCustomerByName(string firstName)
        {
            foreach(var customer in _custList)
            {
                if(firstName.ToLower() == customer.FirstName.ToLower())
                {
                    return customer;
                }
            }
            return default;
        }
        public bool DeleteCustomer(Customer customer)
        {
            bool removed = _custList.Remove(customer);
            return removed;
        }
    }
}
