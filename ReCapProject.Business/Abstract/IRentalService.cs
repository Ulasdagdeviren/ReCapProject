using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Abstract
{
    public interface IRentalService
    {
        Rental Add(Rental rental);
        Rental Update(Rental rental);
       void Delete(Rental rental);

    }
}
