using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDal : EFEntityRepositoryBase<Customer, ReCapDataBaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (ReCapDataBaseContext context = new ReCapDataBaseContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId  equals user.Id

                             select new CustomerDetailDto
                             {
                                 CustomerId=customer.CustomerId,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CompanyName = customer.CompanyName
                             };

                return result.ToList();
            }
        }
    }
}
