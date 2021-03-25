using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Entities.CarDetail
{
   public class BrandDetail
    {
        public int  Id { get; set; }
        public int BrandId { get; set; }
        public int ModelYear { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
