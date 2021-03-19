using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCategoryLimitExceded(carImage.CarId));

            if (result != null)
            {
                return result;
            }


            carImage.ImagePath = FileHelper.AddAsync(file);


            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();

        }
        public IDataResult<CarImage> Get(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(p => p.Id == Id));
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.GetById(p => p.Id == carImage.Id).ImagePath}";
            FileHelper.DeleteAsync(oldpath);

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.GetById(p => p.Id == carImage.Id).ImagePath}";
            carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = carId, ImagePath = @"\Images\default.jpg" });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));

        }

        private IResult CheckIfCategoryLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult("Bir Arabanın en fazla 5 resmi olabilir");
            }

            return new SuccessResult();
        }
    }
}
