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
        public List<RentDetailDto> GetRentalDetailsByUserId(int userId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on r.UserId equals u.Id
                             where r.UserId == userId
                             select new RentDetailDto
                             {
                                 CarName = c.CarName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarId = c.Id,
                                 Id = r.Id,
                                 UserId = r.UserId,
                                 UserName = u.FirstName + " " + u.LastName,
                                 StFirstCarImage = context.CarImages.FirstOrDefault(t => t.CarId == c.Id && t.BoFirst == true).ImagePath,
                                 DailyPrice = c.DailyPrice,
                                 InTotalDays = r.InTotalDays,
                                 FlTotalPrice = r.FlTotalPrice,
                                 BoPaid = r.BoPaid,
                                 FindexNo=c.FindexNo
                             };
                return result.ToList();

            }
        }
        public RentDetailDto GetRentalDetailsByCarId(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             orderby r.RentDate descending
                             select new RentDetailDto
                             {
                                 CarName = c.CarName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarId = c.Id,
                                 Id = r.Id,
                                 FindexNo = c.FindexNo
                             };
                return result.FirstOrDefault();

            }
        }

        public List<RentDetailDto> GetRentDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on r.UserId equals u.Id orderby r.RentDate descending
                           
                             select new RentDetailDto
                             {
                                 CarName = c.CarName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarId = c.Id,
                                 Id = r.Id,
                                 UserId = r.UserId,
                                 UserName = u.FirstName + " " + u.LastName,
                                 StFirstCarImage = context.CarImages.FirstOrDefault(t => t.CarId == c.Id && t.BoFirst == true).ImagePath,
                                 DailyPrice = c.DailyPrice,
                                 InTotalDays = r.InTotalDays,
                                 FlTotalPrice = r.FlTotalPrice,
                                 BoPaid = r.BoPaid,
                                 FindexNo = c.FindexNo,
                                 BrandName=b.BrandName
                             };
                return result.ToList();

            }
        }
    }
}
