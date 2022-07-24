using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            if (ValidateRental(entity) != null)
            {
                return ValidateRental(entity);
            }

            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(Rental entity)
        {
            if (ValidateRental(entity) != null && entity.CarId != GetById(entity.Id).Data.CarId)
            {
                return ValidateRental(entity);
            }

            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        private bool CheckIfReturnDateIsNull(int carId)
        {
            bool result = false;

            var checkedRental = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate != null);

            if (checkedRental == null)
            {
                result = true;
            }

            return result;
        }

        private IResult ValidateRental(Rental rental)
        {
            if (!CheckIfReturnDateIsNull(rental.CarId))
            {
                return new ErrorResult(Messages.RentalReturnDateInvalid);
            }

            return null;
        }
    }
}
