using Business.Abstract;
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

            //BrandTest();

            //ColorTest();

            //CustomerTest();

            //UserTest();

            //RentalTest();
        }

        private static void RentalTest()
        {
            Console.WriteLine("--------- RENTAL TEST ---------");
            IRentalService rentalManager = new RentalManager(new EfRentalDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentalId + " " + rental.ReturnDate);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(rentalManager.GetById(1).Data.RentalId + " " + rentalManager.GetById(1).Data.ReturnDate);

            Console.WriteLine("--------- Add ---------");
            var resultAdd = rentalManager.Add(new Rental { RentalId = 6, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null });
            Console.WriteLine(resultAdd.Message);
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentalId + " " + rental.ReturnDate);
            }

            Console.WriteLine("--------- Cars That Can Be Rented ---------");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var rental in rentalManager.GetAll().Data)
            {
                if (rental.ReturnDate != null)
                {
                    Console.WriteLine(carManager.GetById(rental.CarId).Data.CarName);
                }
            }

            Console.WriteLine("--------- Rental Process Fail ---------");
            Console.WriteLine(rentalManager.Add(new Rental { RentalId = 7, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null }).Message);

            Console.WriteLine("--------- Update ---------");
            var resultUpdate = rentalManager.Update(new Rental { RentalId = 6, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now });
            Console.WriteLine(resultUpdate.Message);
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentalId + " " + rental.ReturnDate);
            }

            Console.WriteLine("--------- Delete ---------");
            var resultDelete = rentalManager.Delete(new Rental { RentalId = 6 });
            Console.WriteLine(resultDelete.Message);
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentalId + " " + rental.ReturnDate);
            }
        }

        private static void UserTest()
        {
            Console.WriteLine("--------- USER TEST ---------");
            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(userManager.GetById(1).Data.FirstName + " " + userManager.GetById(1).Data.LastName);

            Console.WriteLine("--------- Add ---------");
            var resultAdd = userManager.Add(new User { UserId = 6, FirstName = "Ffff", LastName = "Ffff", Email = "f@gmail.com", Password = "f" });
            Console.WriteLine(resultAdd.Message);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }

            Console.WriteLine("--------- Update ---------");
            var resultUpdate = userManager.Update(new User { UserId = 6, FirstName = "Fffffff", LastName = "Fffffff", Email = "f@gmail.com", Password = "f" });
            Console.WriteLine(resultUpdate.Message);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }

            Console.WriteLine("--------- Delete ---------");
            var resultDelete = userManager.Delete(new User { UserId = 6 });
            Console.WriteLine(resultDelete.Message);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
        }

        private static void CustomerTest()
        {
            Console.WriteLine("--------- CUSTOMER TEST ---------");
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Console.WriteLine("--------- GetAll ---------");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " " + customer.CompanyName);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(customerManager.GetById(1).Data.CustomerId + " " + customerManager.GetById(1).Data.CompanyName);

            Console.WriteLine("--------- Add ---------");
            var resultAdd = customerManager.Add(new Customer { CustomerId = 6, UserId = 1, CompanyName = "F" });
            Console.WriteLine(resultAdd.Message);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " " + customer.CompanyName);
            }

            Console.WriteLine("--------- Update ---------");
            var resultUpdate = customerManager.Update(new Customer { CustomerId = 6, UserId = 1, CompanyName = "FFF" });
            Console.WriteLine(resultUpdate.Message);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " " + customer.CompanyName);
            }

            Console.WriteLine("--------- Delete ---------");
            var resultDelete = customerManager.Delete(new Customer { CustomerId = 6 });
            Console.WriteLine(resultDelete.Message);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " " + customer.CompanyName);
            }
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
            var resultGetAll = carManager.GetAll();
            if (resultGetAll.Success)
            {
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(resultGetAll.Message);
            }

            Console.WriteLine("--------- GetById ---------");
            Console.WriteLine(carManager.GetById(1).Data.CarName);

            Console.WriteLine("--------- GetCarsByBrandId ---------");
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("--------- GetCarsByColorId ---------");
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("--------- GetCarsByDailyPrice ---------");
            var resultDailyPrice = carManager.GetCarsByDailyPrice(100, 300);
            if (resultDailyPrice.Success)
            {
                foreach (var car in resultDailyPrice.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(resultDailyPrice.Message);
            }

            Console.WriteLine("--------- GetDetailsOfCars ---------");
            foreach (var car in carManager.GetDetailsOfCars().Data)
            {
                Console.WriteLine("Car Name: " + car.CarName + " - Brand Name: " + car.BrandName + " - Color Name:" + car.ColorName + " - Daily Price: " + car.DailyPrice);
            }

            Console.WriteLine("--------- GetCarDetails ---------");
            Console.WriteLine("Car Name: " + carManager.GetCarDetails(1).Data.CarName + " - Brand Name: " + carManager.GetCarDetails(1).Data.BrandName + " - Color Name: " + carManager.GetCarDetails(1).Data.ColorName + " - Daily Price: " + carManager.GetCarDetails(1).Data.DailyPrice);

            Console.WriteLine("--------- Add ---------");
            var resultAdd = carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "x", ModelYear = 2016, CarName = "Araba66" });
            Console.WriteLine(resultAdd.Message);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("--------- Update ---------");
            var resultUpdate =carManager.Update(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "x", ModelYear = 2016, CarName = "Araba6" });
            Console.WriteLine(resultUpdate.Message);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("--------- Delete ---------");
            var resultDelete = carManager.Delete(new Car { CarId = 6 });
            Console.WriteLine(resultDelete.Message);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("--------- Adding Process Fail ---------");
            Console.WriteLine(carManager.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "x", ModelYear = 2016, CarName = "A" }).Message);
        }
    }
}
