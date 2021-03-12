using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDal : EFEntityRepositoryBase<Customer, ReCapDataBaseContext>, ICustomerDal
    {
    }
}
