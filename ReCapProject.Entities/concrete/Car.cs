using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; } //Marka
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; } // Günlük Fiyat
        public string Description { get; set; }     // Açıklama

    }
}
