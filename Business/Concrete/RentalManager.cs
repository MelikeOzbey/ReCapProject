using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        IUserDal _userDal;
        ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, IUserDal userDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _userDal = userDal;
            _carDal = carDal;
        }

        public IResult Add(Rental rental)
        {
           
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentedCar);
        }

        public IResult CheckCarAvailable(int id, DateTime date)
        {
            IResult result = BusinessRules.Run(CheckIfCarIsAvailable(id, date));
            if (result != null)
            {
                return result;
            }

            return new SuccessResult(Messages.CarAvailable);
        }
        public IResult CheckFindexOfUserIsOK(int carId, int userId)
        {
            IResult result = BusinessRules.Run(CheckIfFindexOfUserIsAvailable(carId, userId));
            if (result != null)
            {
                return result;
            }

            return new SuccessResult(Messages.CarAvailable);
        }


        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentalDal.GetRentDetails());
        }

        public IDataResult<List<RentDetailDto>> GetRentalDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentalDal.GetRentalDetailsByUserId(userId));
        }

        public IDataResult<RentDetailDto> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<RentDetailDto>(_rentalDal.GetRentalDetailsByCarId(carId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updatetd);
        }

        private IResult CheckIfCarIsAvailable(int carId, DateTime date)
        {
            var car = _rentalDal.GetRentalDetailsByCarId(carId);
            if(car!=null && car.ReturnDate!=null && car.ReturnDate> date)
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }
            return new SuccessResult();

        }
        private IResult CheckIfFindexOfUserIsAvailable(int carId, int userId)
        {
            var car = _carDal.Get(x=>x.Id==carId);
            var user = _userDal.Get(x=>x.Id==userId);
            if (car.FindexNo>user.FindexNo)
            {
                return new ErrorResult(Messages.CarFindexAvailable);
            }
            return new SuccessResult();

        }

        public IDataResult<List<RentDetailDto>> GetPaidRentalDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentalDal.GetPaidRentalDetailsByUserId(userId));
        }
    }
}
