using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Http;
using ReCapProject.Core.Utilities.Result.Abstract;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImage();
        IResult Update(IFormFile file, CarImage ımage);
        IResult Add(IFormFile file, CarImage ımage);
        IResult Delete(CarImage ımage);

    }
}
