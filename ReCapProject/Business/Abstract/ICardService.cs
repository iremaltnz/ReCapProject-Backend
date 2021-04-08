using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICardService
    {
        IResult Add(Card card);
        IResult Delete(Card card);
        IResult Update(Card card);
        IDataResult<List<Card>> GetByUserId(int userId);

        IDataResult<List<Card>> Get();
    }
}
