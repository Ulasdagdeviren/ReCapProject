using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
   public class EfColorDal:EfRepositoryBase<CarColor,CarContext>,IColorDal
    {
        public List<ColorDetail> GetCars(string color)
        {
            using (CarContext context=new CarContext())
            {
                var result = from c in context.Cars
                    join col in context.CarColors on c.ColorId equals col.ColorId
                    join b in context.CarBrands on c.BrandId equals b.BrandId 
                    where col.Color == color
                    select new ColorDetail
                    {
                        Id = c.Id,
                        ColorId = col.ColorId,
                        Color = col.Color,
                        Brand = b.Brand,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear
                    };
                return result.ToList();
            }
        }
    }
}
