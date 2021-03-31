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
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetCarById ---------");
            Console.WriteLine("Description: " + carManager.GetCarById(1).Description + " Model Year: " + carManager.GetCarById(1).ModelYear + " Daily Price: " + carManager.GetCarById(1).DailyPrice);

            Console.WriteLine("--------- GetCarsByBrandId ---------");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetCarsByColorId ---------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetCarsByDailyPrice ---------");
            foreach (var car in carManager.GetCarsByDailyPrice(100, 300))
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Add ---------");
            carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "fff", ModelYear = 2016 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Update ---------");
            carManager.Update(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "fffffffff", ModelYear = 2016 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Delete ---------");
            carManager.Delete(new Car { CarId = 6 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- Adding Process Fail ---------");
            carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 0, Description = "f", ModelYear = 2016 });
        }
    }
}
