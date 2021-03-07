using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.concrete
{
   public class CarImage:IEntity
   {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

   }
}
