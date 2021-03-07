using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.BusinessAspect.Autofac;
using ReCapProject.Business.Cantact;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspect.Autofac.Caching;
using ReCapProject.Core.Aspect.Autofac.Validation;
using ReCapProject.Core.CrossCutingConcern.Caching.Microsoft;
using ReCapProject.Core.CrossCutingConcern.Logging.Log4Net.Loggers;
using ReCapProject.Core.Result.Concrete;
using ReCapProject.Core.Utilities.BusinessRules;
using ReCapProject.Core.Utilities.Result.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Concrete.Managers
{
    public class CarManager : ICarService 
    {
        private ICarDal _carDal;
        //private ICarImageService _service; // mikroservis inşa ediyoruz

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
           
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //return _carDal.GetAll();
            //if (DateTime.Now.Hour==23)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarDataListed);
        }

        

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }
        [Core.Aspect.Autofac.Validation.ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("product.add,admin")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

    }
}
