using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface ICustomerRepository
    {
        // CustomerRepository Interface
        // Create Data
        Customer Create(Customer customer);
        // Read Data
        Customer ReadById(int id);
        List<Customer> ReadAll();
        // Update Data
        Customer UpdateCustomer(Customer customerUpdate);
        // Delete Data
        Customer Delete(int id);


    }
}
