using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             select new RentDetailDto
                             {
                                 CarName = c.CarName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarId=c.Id,
                                 Id=r.Id
                             };
                return result.ToList();

            }
        }
    }
}
