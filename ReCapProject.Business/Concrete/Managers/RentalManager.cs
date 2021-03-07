using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Concrete.Managers
{
   public class RentalManager:IRentalService
   {
       private IRentalDal _rentalDal;

       public RentalManager(IRentalDal rentalDal)
       {
           _rentalDal = rentalDal;
       }

       public Rental Add(Rental rental)
       {
           return _rentalDal.Add(rental);
       }

       public Rental Update(Rental rental)
       {
           return _rentalDal.Update(rental);
       }

       public void Delete(Rental rental)
       {
           _rentalDal.Delete(rental);
       }
   }
}
