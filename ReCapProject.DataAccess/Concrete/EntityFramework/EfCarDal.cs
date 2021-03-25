using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
   public class EfCarDal:EfRepositoryBase<Car,CarContext>,ICarDal
    {
        
    }
}
