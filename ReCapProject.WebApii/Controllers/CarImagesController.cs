using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ReCapProject.Business.Abstract;
using ReCapProject.Core.Utilities.FileHelper;
using ReCapProject.Entities.concrete;

namespace ReCapProject.WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        private IWebHostEnvironment _environment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment environment)
        {
            _carImageService = carImageService;
            _environment = environment;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carImageService.GetAllCarImage();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult AddImage([FromForm(Name = ("Image"))] IFormFile file,[FromForm] CarImage ımage)
        {
            var result = _carImageService.Add(file, ımage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            string path = _environment.WebRootPath + "\\Images";
            FileHelper.Delete(path + "\\" + carImage.ImagePath);

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
