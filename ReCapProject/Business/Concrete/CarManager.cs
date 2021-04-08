using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private IBrandDal _brandDal;
        private IColorDal _colorDal;

        public CarManager(ICarDal carDal,IBrandDal brandDal,IColorDal colorDal)
        {

            _carDal = carDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
        }


        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetail);

        }

        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);

        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {

            return new SuccessDataResult<Car>(_carDal.GetById(c => c.CarId == id), Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarListed);

        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarListed);


        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 5)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(car=>car.BrandName == _brandDal.GetById(b=>b.BrandId==brandId).BrandName).ToList(), Messages.CarDetail);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(car => car.ColorName == _colorDal.GetById(color => color.ColorId == colorId).ColorName).ToList(), Messages.CarDetail);
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int carId)
        {
           
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(carId),Messages.CarDetail);
        }

        public IDataResult<List<CarDetailDto>> GetCarFilter(int colorId,int brandId)
        {
            if(brandId==0 && colorId==0) return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().ToList(), "filtre yok");
            else if(colorId!=0 && brandId==0) return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.ColorName == _colorDal.GetById(b => b.ColorId == colorId).ColorName).ToList(), "color filtresi var");
            else if(colorId==0 && brandId!=0) return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.BrandName == _brandDal.GetById(b => b.BrandId == brandId).BrandName).ToList(),"brand var");
            else return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(
                car => (car.ColorName == _colorDal.GetById( color => color.ColorId == colorId).ColorName)&&
                (car.BrandName == _brandDal.GetById(brand => brand.BrandId == brandId).BrandName)).ToList(), "her iki filtre de vr");
        }
    }

    }


    

