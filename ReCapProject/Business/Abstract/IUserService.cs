using Core.Entities.Concrete;
using Core.Utilities.Result;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMail(string email);
    }
}
