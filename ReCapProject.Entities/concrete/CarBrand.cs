using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.concrete
{
   public class CarBrand:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }

    }
}
