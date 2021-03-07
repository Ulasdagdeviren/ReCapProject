using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Abstract
{
    public interface ICustomerService
    {
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        void Delete(Customer customer);
    }
}
