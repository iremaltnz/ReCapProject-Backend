using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindexManager : IFindexService
    {
        ICarService _carService;
        ICustomerService _customerService;
        int carFindexSore;
        int customerFindexScore;
        public FindexManager(ICarService carService, ICustomerService customerService)
        {
            _carService = carService;
            _customerService = customerService;
        }

        public IResult FindexCheck(int customerId, int carId)
        {
            customerFindexScore = _customerService.GetById(customerId).Data.FindexScore;
            carFindexSore = _carService.GetById(carId).Data.MinFindexScore;

            if (carFindexSore>customerFindexScore)
            {
                return new ErrorResult(Messages.FindexCheckError);
            }

            return new SuccessResult(Messages.FindexCheckSuccess);
        }
    }
}
