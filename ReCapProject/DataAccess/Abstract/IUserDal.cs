using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
