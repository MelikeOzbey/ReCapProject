using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public CarDetailDto GetCarDetailById(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             where c.Id == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 ModelYear = c.ModelYear,
                                 StFirstCarImage = context.CarImages.FirstOrDefault(t => t.CarId == c.Id && t.BoFirst == true).ImagePath,
                                 FindexNo=c.FindexNo

                             };

                return result.FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 Description = c.Description,
                                 StFirstCarImage = context.CarImages.FirstOrDefault(t => t.CarId == c.Id && t.BoFirst == true).ImagePath,
                                 FindexNo = c.FindexNo

                             };
                return result.ToList();
            }


        }

        public List<CarDetailDto> GetCarsDetailByBrandId(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             where c.BrandId == brandId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 StFirstCarImage = context.CarImages.FirstOrDefault(t => t.CarId == c.Id && t.BoFirst == true).ImagePath,
                                 FindexNo = c.FindexNo

                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailByColorId(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             where c.ColorId == colorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 StFirstCarImage = context.CarImages.FirstOrDefault(t => t.CarId == c.Id && t.BoFirst == true).ImagePath,
                                 FindexNo = c.FindexNo

                             };

                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             where c.BrandId == brandId && c.ColorId== colorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 StFirstCarImage = context.CarImages.FirstOrDefault(t => t.CarId == c.Id && t.BoFirst == true).ImagePath,
                                 FindexNo = c.FindexNo

                             };

                return result.ToList();
            }
        }

    }
}
