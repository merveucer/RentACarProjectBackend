using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car entity)
        {
            if (validateCar(entity) != null)
            {
                return validateCar(entity);
            }            

            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car entity)
        {
            if (validateCar(entity) != null)
            {
                return validateCar(entity);
            }

            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetAllWithCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllWithCarDetails());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<CarDetailDto> GetWithCarDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetWithCarDetails(c => c.Id == id));
        }

        private bool CheckIfNameLengthIsMinTwoChars(String name)
        {
            bool result = false;

            if (name.Length >= 2)
            {
                result = true;
            }

            return result;
        }

        private bool CheckIfDailyPriceIsGreaterThanZero(decimal dailyPrice)
        {
            bool result = false;

            if (dailyPrice > 0)
            {
                result = true;
            }

            return result;
        }

        private IResult validateCar(Car car)
        {
            if (!CheckIfNameLengthIsMinTwoChars(car.Name))
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }

            if (!CheckIfDailyPriceIsGreaterThanZero(car.DailyPrice))
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }

            return null;
        }
    }
}
