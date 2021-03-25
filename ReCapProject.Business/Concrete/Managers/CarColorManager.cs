using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Concrete.Managers
{
  public class CarColorManager:ICarColorService
  {
      private IColorDal _colorDal;

      public CarColorManager(IColorDal colorDal)
      {
          _colorDal = colorDal;
      }

      public List<ColorDetail> Cars(string color)
      {
          return _colorDal.GetCars(color);
      }
    }
}
