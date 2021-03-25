using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Abstract
{
   public interface ICarColorService
   {
       List<ColorDetail> Cars(string color);
   }
}
