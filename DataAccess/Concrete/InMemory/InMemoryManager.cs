using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryManager : ICarDal
    {
        List<Car> _cars;

        public InMemoryManager()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1, ModelYear=2000, DailyPrice=200,Description="Toyota düz vites"},
                new Car{Id=2,BrandId=2,ColorId=5, ModelYear=2000, DailyPrice=200,Description="BMW düz vites"},
                new Car{Id=3,BrandId=2,ColorId=5, ModelYear=2000, DailyPrice=250,Description="BMW otomatik vites"},
                new Car{Id=4,BrandId=3,ColorId=4, ModelYear=2000, DailyPrice=210,Description="Seat düz vites"},
                new Car{Id=5,BrandId=4,ColorId=6, ModelYear=2000, DailyPrice=220,Description="Opel düz vites"}
            };
        }

        public void Add(Car car)
        {
            Car myCar = new Car();
            myCar.Id = car.Id;
            myCar.BrandId = car.BrandId;
            myCar.ColorId = car.ColorId;
            myCar.ModelYear = car.ModelYear;
            myCar.DailyPrice = car.DailyPrice;
            myCar.Description = car.Description;
            _cars.Add(myCar);
            
        }

        public void Delete(Car car)
        {
            var myCar = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(myCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(x => x.Id == id);
        }

        public CarDetailDto GetCarDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var myCar = _cars.SingleOrDefault(x => x.Id == car.Id);
            myCar.Id = car.Id;
            myCar.BrandId = car.BrandId;
            myCar.ColorId = car.ColorId;
            myCar.ModelYear = car.ModelYear;
            myCar.DailyPrice = car.DailyPrice;
            myCar.Description = car.Description;
        }
    }
}
