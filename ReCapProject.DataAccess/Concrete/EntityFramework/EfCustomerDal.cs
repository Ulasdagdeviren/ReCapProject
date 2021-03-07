using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.concrete;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal:EfRepositoryBase<Customer,CarContext>,ICustomerDal
    {

    }
}
