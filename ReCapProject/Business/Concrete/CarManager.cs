using Business.Abstract;
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
        public void Add(Car car)
        {
            if (car.DailyPrice>0 && car.CarName.Length>=2 )
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba günlük fiyati 0 dan büyük olmali ve araba ismi minimum iki karakter olmalidir. Ekleme Basarisiz!!" );
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(c=>c.CarId==id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
