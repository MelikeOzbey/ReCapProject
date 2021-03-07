using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
              _carDal.Add(car);
                return new SuccessResult(Messages.Added);
           
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.List);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == carId));
        }

        public IDataResult<CarDetailDto> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailById(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(filter));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),Messages.List);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updatetd);
        }
    }
}
