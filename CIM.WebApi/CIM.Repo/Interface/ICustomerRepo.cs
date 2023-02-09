using CIM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIM.Repo.Interface
{
    public interface ICustomerRepo
    {
        void SaveCustomerData(Customer customer);
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomers();
        void DeleteCustomer(int id);
    }
}
