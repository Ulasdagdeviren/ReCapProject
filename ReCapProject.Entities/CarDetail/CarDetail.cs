using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Entities.CarDetail
{
   public class CarDetail
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Brand { get; set; }
    }
}
