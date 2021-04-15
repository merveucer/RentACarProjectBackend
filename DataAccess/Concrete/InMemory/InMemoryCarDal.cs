using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100,Description="x",ModelYear=2020},
                new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=200,Description="y",ModelYear=2020},
                new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=300,Description="z",ModelYear=2020},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetDetailsOfCars()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        CarDetailDto ICarDal.GetCarDetails(Expression<Func<CarDetailDto, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
