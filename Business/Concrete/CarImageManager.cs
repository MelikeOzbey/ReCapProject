using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file,CarImage image)
        {
            var result = BusinessRules.Run(CheckIfCarImagesLimitedExceeded(image.CarId));
            if(result!=null)
            {
                return result;
            }
            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            image.CarId = image.CarId;

            _carImageDal.Add(image);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage image)
        {
            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x=>x.Id==id));
        }

        public IDataResult<List<CarImage>> GetImagesByCar(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfImagesNull(carId));
        }

        public IResult Update(IFormFile file, CarImage image)
        {
            image.ImagePath = FileHelper.Update(_carImageDal.Get(i=>i.Id==image.Id).ImagePath,file);
            image.Date = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult(Messages.Updatetd);
        }
        private IResult CheckIfCarImagesLimitedExceeded(int carId)
        {
            var carImagesCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(carImagesCount>=5)
            {
                return new ErrorResult(Messages.CarImagesLimitedExceeded);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfImagesNull(int id)
        {
           
            var carImages = _carImageDal.GetAll(c => c.CarId == id);
            if(carImages.Count()==0)
            {
                string path = Environment.CurrentDirectory + @"\Images";
                string newPath = $@"{path}\logo.jpg";
                List<CarImage> images = new List<CarImage> { 
                 new CarImage{CarId=id,ImagePath=newPath,Date=DateTime.Now}
                };
                return images;
            }

            return carImages;
            
        }

       
    }
}
