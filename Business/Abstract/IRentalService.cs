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
        IResult CheckFindexOfUserIsOK(int carId, int userId);
        IResult CheckCarAvailable(int id, DateTime date);
        IDataResult<List<RentDetailDto>> GetRentalDetails();
        IDataResult<List<RentDetailDto>> GetRentalDetailsByUserId(int userId);
    }
}
