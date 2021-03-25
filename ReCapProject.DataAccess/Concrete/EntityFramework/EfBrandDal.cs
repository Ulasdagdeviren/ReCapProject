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
   public class EfBrandDal:EfRepositoryBase<CarBrand,CarContext>,IBrandDal
    {
        public List<BrandDetail> GetCars(string brand)
        {
            using (CarContext context=new CarContext())
            {
                var result = from b in context.CarBrands
                    join c in context.Cars on b.BrandId equals c.BrandId
                    join col in context.CarColors on c.ColorId equals col.ColorId 
                    where b.Brand==brand
                    where c.ColorId==col.ColorId
                    select new BrandDetail
                    {
                        Id = b.Id,
                        BrandId = b.BrandId,
                        Color = col.Color,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        Brand = b.Brand
                    };
                return result.ToList();
            }
        }
    }
}
