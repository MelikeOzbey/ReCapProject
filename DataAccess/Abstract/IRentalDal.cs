using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentDetailDto> GetRentDetails();
        RentDetailDto GetRentalDetailsByCarId(int carId);
        List<RentDetailDto> GetRentalDetailsByUserId(int userId);
        List<RentDetailDto> GetPaidRentalDetailsByUserId(int userId);
    }
}
