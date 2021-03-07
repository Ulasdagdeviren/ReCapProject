using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Result.Abstract;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Abstract
{
   public interface ICarService
   {
       IDataResult<List<Car>> GetAll();
       
       IDataResult<Car> Get(int id);
       IResult Add(Car car);
       IResult Update(Car car);
      void Delete(Car car);
   }
}
