using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        private List<CarDetailDto> JoinCar ()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 Name = car.Name,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };

                return result.ToList();
            }
        }
        
        public List<CarDetailDto> GetAllWithCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return JoinCar();
        }

        public CarDetailDto GetWithCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return JoinCar().ElementAt(0);
        }
    }
}
