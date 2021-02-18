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
            //InMemoryTest();

            // EFCarDalTest();

            // ColorTest();

            //  BrandTest();

            // CarTest();

            //UserTest();

            // RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            Rental rental = new Rental { CarId = 1, CustomerId = 1, Id = 4, RentDate = new DateTime(2021, 1, 15, 7, 0, 0), ReturnDate = new DateTime(2021, 1, 16, 7, 0, 0) };

            Console.WriteLine(rentalManager.Add(rental).Message);
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EFUserDal());

            foreach (var u in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1} {2} ", u.FirstName, u.LastName, u.Email);
            }



            User user = new User { Id = 3, FirstName = "Ali", LastName = "Altnz", Email = "789@gmail.com", Password = "+++" };

            userManager.Add(user);

            foreach (var u in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1} {2} ", u.FirstName, u.LastName, u.Email);
            }



            user.FirstName = "Ayşe";

            userManager.Update(user);

            foreach (var u in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1} {2} ", u.FirstName, u.LastName, u.Email);
            }


            userManager.Delete(user);
            foreach (var u in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1} {2} ", u.FirstName, u.LastName, u.Email);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var c in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", c.CarName, c.BrandName, c.ColorName, c.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());

            foreach (var b in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1}", b.BrandId, b.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0}  {1}", c.ColorId, c.ColorName);
            }
        }

        private static void EFCarDalTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var c in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine(carManager.GetById(2).Data.CarName);
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var c in carManager.GetAll().Data)
            {
                Console.WriteLine(c.Description);
            }
        }
    }
    
}
