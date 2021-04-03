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
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(colorManager.GetById(1).ColorId + " " + colorManager.GetById(1).ColorName);

            Console.WriteLine("--------- Add ---------");
            colorManager.Add(new Color { ColorId = 6, ColorName = "Lacivert" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            Console.WriteLine("--------- Update ---------");
            colorManager.Update(new Color { ColorId = 6, ColorName = "Yeşil" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            Console.WriteLine("--------- Delete ---------");
            colorManager.Delete(new Color { ColorId = 6 });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            Console.WriteLine("--------- BRAND TEST ---------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(brandManager.GetById(1).BrandId + " " + brandManager.GetById(1).BrandName);

            Console.WriteLine("--------- Add ---------");
            brandManager.Add(new Brand { BrandId = 6, BrandName = "Marka66" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }

            Console.WriteLine("--------- Update ---------");
            brandManager.Update(new Brand { BrandId = 6, BrandName = "Marka6" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }

            Console.WriteLine("--------- Delete ---------");
            brandManager.Delete(new Brand { BrandId = 6 });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            Console.WriteLine("--------- CAR TEST ---------");
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("-Description: " + car.Description + " -Model Year: " + car.ModelYear + " -Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine("-Description: " + carManager.GetById(1).Description + " -Model Year: " + carManager.GetById(1).ModelYear + " -Daily Price: " + carManager.GetById(1).DailyPrice);

            Console.WriteLine("--------- GetCarsByBrandId ---------");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("-Description: " + car.Description + " -Model Year: " + car.ModelYear + " -Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetCarsByColorId ---------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("-Description: " + car.Description + " -Model Year: " + car.ModelYear + " -Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetCarsByDailyPrice ---------");
            foreach (var car in carManager.GetCarsByDailyPrice(100, 300))
            {
                Console.WriteLine("-Description: " + car.Description + " -Model Year: " + car.ModelYear + " -Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetCarDetails ---------");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("-Car Name: " + car.CarName + " -Brand Name: " + car.BrandName + " -Color Name:" + car.ColorName + " -DailyPrice: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Add ---------");
            carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "fff", ModelYear = 2016, CarName = "FF" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("-Description: " + car.Description + " -Model Year: " + car.ModelYear + " -Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Update ---------");
            carManager.Update(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "fffffffff", ModelYear = 2016, CarName = "FF" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("-Description: " + car.Description + " -Model Year: " + car.ModelYear + " -Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Delete ---------");
            carManager.Delete(new Car { CarId = 6 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("-Description: " + car.Description + " -Model Year: " + car.ModelYear + " -Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Adding Process Fail ---------");
            carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 0, Description = "fff", ModelYear = 2016, CarName = "F" });
        }
    }
}
