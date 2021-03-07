using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Concrete.Managers
{
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }

       public Customer Add(Customer customer)
       {
           return _customerDal.Add(customer);
       }

        public Customer Update(Customer customer)
        {
            return _customerDal.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }
    }
}
