using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFBrandDal : EFEntityRepositoryBase<Brand, ReCapDataBaseContext>, IBrandDal
    {

    }
}