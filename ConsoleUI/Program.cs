using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            BrandTest();
            ColorTest();
        }

        private static void ColorTest()
        {
            Console.WriteLine("--- COLOR ---");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color { Id=4, Name="Renk 4" };

            void GetAll()
            {
                foreach (Color color in colorManager.GetAll().Data)
                {
                    Console.WriteLine(color.Id + " " + color.Name);
                }
            }

            Console.WriteLine("--- GetAll ---");
            GetAll();

            Console.WriteLine("--- GetById ---");
            var result = colorManager.GetById(1).Data;
            Console.WriteLine(result.Id + " " + result.Name);

            Console.WriteLine("--- Add ---");
            Console.WriteLine(colorManager.Add(color).Message);
            GetAll();

            Console.WriteLine("--- Update ---");
            color.Name = "Renk 5";
            Console.WriteLine(colorManager.Update(color).Message);
            GetAll();

            Console.WriteLine("--- Delete ---");
            Console.WriteLine(colorManager.Delete(color).Message);
            GetAll();
        }

        private static void BrandTest()
        {
            Console.WriteLine("--- BRAND ---");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand { Id=4, Name ="Marka 4" };

            void GetAll()
            {
                foreach (Brand brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.Id + " " + brand.Name);
                }
            }

            Console.WriteLine("--- GetAll ---");
            GetAll();

            Console.WriteLine("--- GetById ---");
            var result = brandManager.GetById(1).Data;
            Console.WriteLine(result.Id + " " + result.Name);

            Console.WriteLine("--- Add ---");
            Console.WriteLine(brandManager.Add(brand).Message);
            GetAll();

            Console.WriteLine("--- Update ---");
            brand.Name = "Marka 5";
            Console.WriteLine(brandManager.Update(brand).Message);
            GetAll();

            Console.WriteLine("--- Delete ---");
            Console.WriteLine(brandManager.Delete(brand).Message);
            GetAll();
        }

        private static void CarTest()
        {
            Console.WriteLine("--- CAR ---");

            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car { Id=6, BrandId=3, ColorId=3, DailyPrice=600, Description="", Name="C 666", ModelYear=2022 };

            void GetAll()
            {
                foreach (Car car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.Id + " " + car.DailyPrice);
                }
            }
            
            Console.WriteLine("--- GetAll ---");
            GetAll();

            Console.WriteLine("--- GetAllByBrandId ---");
            foreach (Car c in carManager.GetAllByBrandId(1).Data)
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetAllByColorId ---");
            foreach (Car c in carManager.GetAllByColorId(1).Data)
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetAllWithCarDetails ---");
            foreach (CarDetailDto c in carManager.GetAllWithCarDetails().Data)
            {
                Console.WriteLine(c.Id + " " + c.BrandName + " " + c.ColorName);
            }

            Console.WriteLine("--- GetById ---");
            var result1 = carManager.GetById(1).Data;
            Console.WriteLine(result1.Id + " " + result1.DailyPrice);

            Console.WriteLine("--- GetWithCarDetailsById ---");
            var result2 = carManager.GetWithCarDetailsById(1).Data;
            Console.WriteLine(result2.Id + " " + result2.BrandName + " " + result2.ColorName);

            Console.WriteLine("--- Add ---");
            Console.WriteLine(carManager.Add(car).Message);
            GetAll();

            Console.WriteLine("--- Update ---");
            car.DailyPrice = 700;
            Console.WriteLine(carManager.Update(car).Message);
            GetAll();

            Console.WriteLine("--- Delete ---");
            Console.WriteLine(carManager.Delete(car).Message);
            GetAll();

            Console.WriteLine("--- Failed Add Operation ---");
            Console.WriteLine(carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 600, Description = "", Name = "C", ModelYear = 2022 }).Message);
        }
    }
}
