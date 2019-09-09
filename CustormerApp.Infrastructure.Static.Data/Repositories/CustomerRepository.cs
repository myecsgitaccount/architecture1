using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;

namespace CustormerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        static int id = 1;
        private static List<Customer> _customers = new List<Customer>();

        public CustomerRepository()
        {
        }

        public Customer Create(Customer customer)
        {
            customer.Id = id++;
            _customers.Add(customer);
            return customer; 
        }

        public List<Customer> ReadAll()
        {
            return _customers; 
        }

        public Customer ReadById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }                
            }
            return null; 
        }

        // Remove after implementing UOW
        public Customer UpdateCustomer(Customer customerUpdate)
        {
            var customerFromDB = this.ReadById(customerUpdate.Id);
            if (customerFromDB != null)
            {
                customerFromDB.FirstName = customerUpdate.FirstName;
                customerFromDB.LastName = customerUpdate.LastName;
                customerFromDB.Address = customerUpdate.Address;
                return customerFromDB;
            }
            return null;


        }

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        Customer ICustomerRepository.Create(Customer customer)
        {
            var customerFound = this.ReadById(id);
            if (customerFound != null)
            {
                _customers.Remove(customerFound);
                return customerFound;
            }
            return null;
        }
    }
}
