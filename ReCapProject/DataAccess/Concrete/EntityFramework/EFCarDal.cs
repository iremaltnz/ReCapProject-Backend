using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, ReCapDataBaseContext>, ICarDal
    {
        public List<CarDetailDto> CarDetailDto()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDataBaseContext context = new ReCapDataBaseContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             select new CarDetailDto
                             {
                                 CarId=car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description=car.Description,
                                 ModelYear=car.ModelYear
                             };

                return result.ToList();
            }
        }
    }
}