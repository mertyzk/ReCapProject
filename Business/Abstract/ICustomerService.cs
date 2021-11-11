using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        List<Customer> GetCustomersByUserId(int userId);
        public void Add(Customer customer);
        public void Update(Customer customer);
        public void Delete(Customer customer);
    }
}
