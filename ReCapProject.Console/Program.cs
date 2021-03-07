using System;
using System.Linq;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete.Managers;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //CarManager manager=new CarManager(new EfCarDal());
            //var result = manager.GetAll();
            //if (result.Success)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        System.Console.WriteLine(car.Description+"/"+car.ModelYear);
            //    }
            //}
            //else
            //{
            //    System.Console.WriteLine(result.Message);
            //}










         //   ICarService service = new CarManager(new EfCarDal());
           
         //  // System.Console.WriteLine("{0},{1},{2}", car.BrandId, car.DailyPrice, car.ModelYear);
         //   var result = service.Get(1);
           
         //System.Console.WriteLine("{0}   {1}   {2}     {3}   {4}   {5}    ",
         //    result.BrandId,result.DailyPrice,result.Id,result.ModelYear,result.ColorId,result.Description);

         //Car car=new Car
         //{
         //    BrandId = 1,
         //    ColorId = 2,
         //    DailyPrice = 150,
         //    Description = "Aracımız Temizdir",
         //    Id = 1,
         //    ModelYear = 2018
         //};

         //var getAll = service.GetAll();
         //foreach (var car1 in getAll) // bu şekilde de erişim sağlanabilir yani liste varsa foreach döndür
         //{
         //    System.Console.WriteLine(car1.ModelYear);
         //}

         //var getByDetail = service.GetAllCarDetails();
         //foreach (var carDetail in getByDetail)
         //{
         //    System.Console.WriteLine(carDetail);
         //}

        }
    }
}
