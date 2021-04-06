using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
            Console.WriteLine("--------- COLOR TEST ---------");
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(colorManager.GetById(1).Data.ColorId + " " + colorManager.GetById(1).Data.ColorName);

            Console.WriteLine("--------- Add ---------");
            var resultAdd = colorManager.Add(new Color { ColorId = 6, ColorName = "Lacivert" });
            Console.WriteLine(resultAdd.Message);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            Console.WriteLine("--------- Update ---------");
            var resultUpdate = colorManager.Update(new Color { ColorId = 6, ColorName = "Yeşil" });
            Console.WriteLine(resultUpdate.Message);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            Console.WriteLine("--------- Delete ---------");
            var resultDelete = colorManager.Delete(new Color { ColorId = 6 });
            Console.WriteLine(resultDelete.Message);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            Console.WriteLine("--------- BRAND TEST ---------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(brandManager.GetById(1).Data.BrandId + " " + brandManager.GetById(1).Data.BrandName);

            Console.WriteLine("--------- Add ---------");
            var resultAdd = brandManager.Add(new Brand { BrandId = 6, BrandName = "Marka66" });
            Console.WriteLine(resultAdd.Message);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }

            Console.WriteLine("--------- Update ---------");
            var resultUpdate = brandManager.Update(new Brand { BrandId = 6, BrandName = "Marka6" });
            Console.WriteLine(resultUpdate.Message);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }

            Console.WriteLine("--------- Delete ---------");
            var resultDelete = brandManager.Delete(new Brand { BrandId = 6 });
            Console.WriteLine(resultDelete.Message);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            Console.WriteLine("--------- CAR TEST ---------");
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Name: " + car.CarName);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine("Car Name: " + carManager.GetById(1).Data.CarName);

            Console.WriteLine("--------- GetCarsByBrandId ---------");
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine("Car Name: " + car.CarName);
            }

            Console.WriteLine("--------- GetCarsByColorId ---------");
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine("Car Name: " + car.CarName);
            }

            Console.WriteLine("--------- GetCarsByDailyPrice ---------");
            var result = carManager.GetCarsByDailyPrice(100, 300);
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Name: " + car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("--------- GetCarDetails ---------");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car Name: " + car.CarName + " Brand Name: " + car.BrandName + " Color Name:" + car.ColorName + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Add ---------");
            var resultAdd = carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "fff", ModelYear = 2016, CarName = "FF" });
            Console.WriteLine(resultAdd.Message);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Name: " + car.CarName);
            }

            Console.WriteLine("--------- Update ---------");
            var resultUpdate =carManager.Update(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "fff", ModelYear = 2016, CarName = "FFFFF" });
            Console.WriteLine(resultUpdate.Message);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Name: " + car.CarName);
            }

            Console.WriteLine("--------- Delete ---------");
            var resultDelete = carManager.Delete(new Car { CarId = 6 });
            Console.WriteLine(resultDelete.Message);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Name: " + car.CarName);
            }

            Console.WriteLine("--------- Adding Process Fail ---------");
            Console.WriteLine(carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "fff", ModelYear = 2016, CarName = "F" }).Message);
        }
    }
}
