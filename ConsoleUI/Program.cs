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
            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car = new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 600, Description = "", ModelYear = 2022 };

            Console.WriteLine("--- GetAll ---");
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetAllByBrandId ---");
            foreach (Car c in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetAllByColorId ---");
            foreach (Car c in carManager.GetAllByColorId(1))
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetById ---");
            Console.WriteLine(carManager.GetById(1).Id + " " + carManager.GetById(1).DailyPrice);

            Console.WriteLine("--- Add ---");
            carManager.Add(car);
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- Update ---");
            car.DailyPrice = 700;
            carManager.Update(car);
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- Delete ---");
            carManager.Delete(car);
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }
        }
    }
}
