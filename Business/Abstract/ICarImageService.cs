using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage,bool>> filter=null);
        IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile file,CarImage image);
        IResult Delete(CarImage image);
        IResult Update(IFormFile file,CarImage image);
        IDataResult<List<CarImage>> GetImagesByCar(int carId);

    }
}
