using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Abstract
{
   public interface ICarBrandService
   {
       List<BrandDetail> CarBrands(string brand);
   }
}
