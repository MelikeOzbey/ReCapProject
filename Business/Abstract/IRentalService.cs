using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<Rental> CheckCarAvailable(int id);
        IDataResult<List<RentDetailDto>> GetRentalDetails(Expression<Func<Rental,bool>> filter=null);
    }
}
