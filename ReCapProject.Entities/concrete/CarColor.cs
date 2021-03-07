using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.concrete
{
  public class CarColor:IEntity
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
    }
}
