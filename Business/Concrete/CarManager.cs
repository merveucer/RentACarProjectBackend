using Business.Abstract;
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

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2 || car.DailyPrice <= 0)
            {
                return new ErrorResult("Eklemek istediğiniz araba kriterlere uygun değildir.");
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult("Araba eklendi.");
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Araba silindi.");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araba güncellendi.");
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
    }
}
