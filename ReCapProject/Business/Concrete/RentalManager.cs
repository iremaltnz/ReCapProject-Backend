using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IFindexService _findexService;
        List<Rental> _rentals;
        public RentalManager(IRentalDal rentalDal,IFindexService findexService)
        {
            _rentalDal = rentalDal;
            _findexService = findexService;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCar(rental), CheckIfFindexScore(rental.CustomerId, rental.CarId));

            if (result !=null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Check(Rental rental)
        {
            _rentals = _rentalDal.GetAll(r=>r.CarId==rental.CarId);
            foreach (var r in _rentals)
            {
                if ((r.RentDate<=rental.RentDate && rental.RentDate<=r.ReturnDate)||(rental.RentDate<r.RentDate && rental.ReturnDate>r.RentDate))
                {
                    return new ErrorResult(Messages.CheckError);
                }
            }

            return new SuccessResult(Messages.CheckSuccess);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(),Messages.RentalDetailListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckIfFindexScore(int customerId,int carId)
        {
            var result = _findexService.FindexCheck(customerId,carId);
            if (result.Success)
            {
                return new SuccessResult(Messages.FindexCheckSuccess);
            }

            return new ErrorResult(Messages.FindexCheckError);
        }

        private IResult CheckIfCar(Rental rental)
        {
            _rentals = _rentalDal.GetAll(r => r.CarId == rental.CarId);


            if (_rentals.Count(r => r.ReturnDate == null) > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }


            return new SuccessResult(Messages.CheckSuccess);
        }
    }
}
