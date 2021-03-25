using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Concrete.Managers
{
   public class CarBrandManager:ICarBrandService
   {
       private IBrandDal _brandDal;
      

       public CarBrandManager(IBrandDal brandDal)
       {
           _brandDal = brandDal;
           
       }

       public List<BrandDetail> CarBrands(string brand)
       {
           return _brandDal.GetCars(brand);
       }

       
    }
}
