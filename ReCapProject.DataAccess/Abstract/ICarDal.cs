using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.DataAccess.Abstract
{
   public interface ICarDal:IEntityRepository<Car>
   {
   }
}
