using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            if (car.DailyPrice>0 && car.CarName.Length>=2 )
            {
               _carDal.Add(car);
               return new SuccessResult( Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarAddedError);
            }
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

        public IDataResult<List<Car>> GetAll()
        {
            
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
     
        }

        public IDataResult<Car> GetById(int id)
        {
            
                return new SuccessDataResult<Car>(_carDal.GetById(c => c.CarId == id), Messages.CarListed);
        }

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
    }
}
