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
            UserTest();
            CustomerTest();
            RentalTest();
        }

        private static void UserTest()
        {
            Console.WriteLine("--- USER ---");

            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { Id = 5, Email = "e@e.com", FirstName = "Eee", LastName = "Eee", Password = "555" };

            void GetAll()
            {
                foreach (User user in userManager.GetAll().Data)
                {
                    Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
                }
            }

            Console.WriteLine("--- GetAll ---");
            GetAll();

            Console.WriteLine("--- GetById ---");
            var result = userManager.GetById(1).Data;
            Console.WriteLine(result.Id + " " + result.FirstName + " " + result.LastName);

            Console.WriteLine("--- Add ---");
            Console.WriteLine(userManager.Add(user).Message);
            GetAll();

            Console.WriteLine("--- Update ---");
            user.FirstName = "Fff";
            Console.WriteLine(userManager.Update(user).Message);
            GetAll();

            Console.WriteLine("--- Delete ---");
            Console.WriteLine(userManager.Delete(user).Message);
            GetAll();
        }

        private static void CustomerTest()
        {
            Console.WriteLine("--- CUSTOMER ---");

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer { Id = 4, UserId = 4, CompanyName = "D" };

            void GetAll()
            {
                foreach (Customer customer in customerManager.GetAll().Data)
                {
                    Console.WriteLine(customer.Id + " " + customer.CompanyName);
                }
            }

            Console.WriteLine("--- GetAll ---");
            GetAll();

            Console.WriteLine("--- GetById ---");
            var result = customerManager.GetById(1).Data;
            Console.WriteLine(result.Id + " " + result.CompanyName);

            Console.WriteLine("--- Add ---");
            Console.WriteLine(customerManager.Add(customer).Message);
            GetAll();

            Console.WriteLine("--- Update ---");
            customer.CompanyName = "E";
            Console.WriteLine(customerManager.Update(customer).Message);
            GetAll();

            Console.WriteLine("--- Delete ---");
            Console.WriteLine(customerManager.Delete(customer).Message);
            GetAll();
        }

        private static void RentalTest()
        {
            Console.WriteLine("--- RENTAL ---");

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { Id = 6, CarId = 1, CustomerId = 3, RentDate = DateTime.Now, ReturnDate = DateTime.Now };

            void GetAll()
            {
                foreach (Rental rental in rentalManager.GetAll().Data)
                {
                    Console.WriteLine(rental.Id + " " + rental.CarId);
                }
            }

            Console.WriteLine("--- GetAll ---");
            GetAll();

            Console.WriteLine("--- GetById ---");
            var result = rentalManager.GetById(1).Data;
            Console.WriteLine(result.Id + " " + result.CarId);

            Console.WriteLine("--- Add ---");
            Console.WriteLine(rentalManager.Add(rental).Message);
            GetAll();

            Console.WriteLine("--- Failed Add Operation ---");
            Console.WriteLine(rentalManager.Add(new Rental { Id = 7, CarId = 4, CustomerId = 3, RentDate = DateTime.Now, ReturnDate = DateTime.Now }).Message);

            Console.WriteLine("--- Update ---");
            rental.CarId = 2;
            Console.WriteLine(rentalManager.Update(rental).Message);
            GetAll();

            Console.WriteLine("--- Failed Update Operation ---");
            rental.CarId = 5;
            Console.WriteLine(rentalManager.Update(rental).Message);

            Console.WriteLine("--- Delete ---");
            Console.WriteLine(rentalManager.Delete(rental).Message);
            GetAll();
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

            Console.WriteLine("--- Failed Add Operation ---");
            Console.WriteLine(carManager.Add(new Car { Id = 7, BrandId = 1, ColorId = 1, DailyPrice = 700, Description = "", Name = "C", ModelYear = 2022 }).Message);
            Console.WriteLine(carManager.Add(new Car { Id = 8, BrandId = 2, ColorId = 2, DailyPrice = 0, Description = "", Name = "C 888", ModelYear = 2022 }).Message);

            Console.WriteLine("--- Update ---");
            car.DailyPrice = 1000;
            Console.WriteLine(carManager.Update(car).Message);
            GetAll();

            Console.WriteLine("--- Failed Update Operation ---");
            car.Name = "C";
            Console.WriteLine(carManager.Update(car).Message);
            car.Name = "C 666";
            car.DailyPrice = 0;
            Console.WriteLine(carManager.Update(car).Message);

            Console.WriteLine("--- Delete ---");
            Console.WriteLine(carManager.Delete(car).Message);
            GetAll();
        }
    }
}
