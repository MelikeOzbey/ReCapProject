using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetailById(int id);
        List<CarDetailDto> GetCarsDetailByBrandId(int brandId);
        List<CarDetailDto> GetCarsDetailByColorId(int colorId);
        List<CarDetailDto> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);
    }
}
