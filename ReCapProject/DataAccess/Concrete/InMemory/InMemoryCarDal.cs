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
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=2,DailyPrice=50000,Description="2016 Model",ModelYear=2016},
                new Car{CarId=2,BrandId=1,ColorId=1,DailyPrice=40000,Description="2015 Model",ModelYear=2015},
                new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=200000,Description="2020 Model",ModelYear=2020}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

      

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }
        public List<Car> GetById(int id)
        {
                return _cars.Where(c => c.CarId == id).ToList();
        }


        public void Update(Car car)
        {
                Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                carToUpdate.ModelYear = car.ModelYear;
        }
        

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    } }
