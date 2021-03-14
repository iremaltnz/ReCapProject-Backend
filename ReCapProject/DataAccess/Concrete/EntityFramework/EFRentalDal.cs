using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepositoryBase<Rental, ReCapDataBaseContext>, IRentalDal
    {
       public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapDataBaseContext context = new ReCapDataBaseContext())
            {
                var result = from rental in context.Rentals
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join user in context.Users
                             on customer.UserId equals user.Id

                             select new RentalDetailDto
                             {
                                 RentalId=rental.Id,
                                 BrandName = brand.BrandName,
                                 CustomerName = user.FirstName,
                                 CustomerSurname = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
