using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("GetAll");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("GetAllBrand");
            foreach (var car in carManager.GetAllBrand(1))
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("GetAllColor");
            foreach (var car in carManager.GetAllColor(1))
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("Add-Update-Delete");
            carManager.Add(new Car { CarId = 4, BrandId = 4, ColorId = 4, DailyPrice = 400, Description = "j", ModelYear = 2020 });
            carManager.Update(new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "q", ModelYear = 2020 });
            carManager.Delete(new Car { CarId = 2 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description: " + car.Description + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice);
            }
        }
    }
}
