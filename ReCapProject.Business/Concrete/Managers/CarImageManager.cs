using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Cantact;
using ReCapProject.Core.Result.Concrete;
using ReCapProject.Core.Utilities.BusinessRules;
using ReCapProject.Core.Utilities.FileHelper;
using ReCapProject.Core.Utilities.Messages;
using ReCapProject.Core.Utilities.Result.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Concrete.Managers
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IDataResult<List<CarImage>> GetAllCarImage()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, CarImage ımage)
        {
            ımage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == ımage.Id).ImagePath, file);
            ımage.Date = DateTime.Now;

            _carImageDal.Update(ımage);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Add(IFormFile file, CarImage ımage)
        {
            var result = BusinessRules.Run(CheckImageControl(ımage.CarId));
            if (result != null)
            {
                return result;
            }

            ımage.ImagePath = FileHelper.Add(file);
            ımage.Date = DateTime.Now;
            _carImageDal.Add(ımage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage ımage)
        {
            FileHelper.Delete(ımage.ImagePath);
            _carImageDal.Delete(ımage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

       private IResult CheckImageControl(int carId)
        {
            var ımageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (ımageCount > 5)
            {
                return new ErrorResult(Messages.CarImageNotAdded);
            }



            return new SuccessResult(Messages.CarImageAdded);
        }

        private List<CarImage> CheckIfCarImages(int ıd)
        {
            string path = @"Images\logo.jpg";
            var result = _carImageDal.GetAll(c => c.Id==ıd).Any();
            if (!result)
            {
                return new List<CarImage>{new CarImage{CarId = ıd,ImagePath = path,Date = DateTime.Now}};
            }

            return _carImageDal.GetAll(p => p.CarId == ıd);
        }
    }
}
