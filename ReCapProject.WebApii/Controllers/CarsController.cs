using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReCapProject.Business.Abstract;
using ReCapProject.Entities.concrete;

namespace ReCapProject.WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
            
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add()
        {
        var  result = _service.Add(new Car
            {
                ColorId = 2,
                BrandId = 1,
                DailyPrice = 50,
                Description = "Aracımız kullanıma hazır",
                ModelYear = 1985
            });
          if (result.Success)
          {
              return Ok(result);
          }

          return BadRequest(result);
        }

        //[HttpPost]
        //public IActionResult AddImage(CarImage ımage)
        //{
        //    var result = _carImageService.Add(ımage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}
    }
}
