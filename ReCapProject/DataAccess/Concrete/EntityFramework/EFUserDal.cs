using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<User, ReCapDataBaseContext>, IUserDal
    {
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            using (var context = new ReCapDataBaseContext())
            {


                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimsId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return new SuccessDataResult<List<OperationClaim>>(result.ToList());

            }
        }
    }
}