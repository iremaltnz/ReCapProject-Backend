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

            //EFCarDalTest();

            // ColorTest();

            //BrandTest();

            //CarTest();

            //UserTest();

          //   RentalTest();

            //CarImage();

          //   PaymentTest();

            //FindexTest();

        }

        private static void FindexTest()
        {
            FindexManager findexManager = new FindexManager(new CarManager(new EFCarDal(), new EFBrandDal(), new EFColorDal()), new CustomerManager(new EFCustomerDal()));
            Console.WriteLine(findexManager.FindexCheck(3, 11).Message);
        }

        private static void PaymentTest()
        {
            PaymentManager paymentManager = new PaymentManager(new EFPaymentDal());
            foreach (var p in paymentManager.Get().Data)
            {
                Console.WriteLine(p.FirstName);
            }
          
        }

        private static void CarImage()
        {
            CarImageManager carImageManager = new CarImageManager(new EFCarImageDal());
            foreach (var item in carImageManager.GetImagesByCarId(1).Data)
            {
                Console.WriteLine("{0}  {1}", item.CarId, item.ImagePath);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal(),new FindexManager(new CarManager(new EFCarDal(), new EFBrandDal(), new EFColorDal()), new CustomerManager(new EFCustomerDal())));
            Rental rental = new Rental { CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 1, 15, 7, 0, 0), ReturnDate = new DateTime(2021, 1, 16, 7, 0, 0) };

            Console.WriteLine(rentalManager.Add(rental).Message);
        }

        //private static void usertest()
        //{
        //    usermanager usermanager = new usermanager(new efuserdal());

        //    foreach (var u in usermanager.getall().data)
        //    {
        //        console.writeline("{0} {1} {2} ", u.firstname, u.lastname, u.email);
        //    }



        //    user user = new user { ıd = 3, firstname = "ali", lastname = "altnz", email = "789@gmail.com", password = "+++" };

        //    usermanager.add(user);

        //    foreach (var u in usermanager.getall().data)
        //    {
        //        console.writeline("{0} {1} {2} ", u.firstname, u.lastname, u.email);
        //    }



        //    user.firstname = "ayşe";

        //    usermanager.update(user);

        //    foreach (var u in usermanager.getall().data)
        //    {
        //        console.writeline("{0} {1} {2} ", u.firstname, u.lastname, u.email);
        //    }


        //    usermanager.delete(user);
        //    foreach (var u in usermanager.getall().data)
        //    {
        //        console.writeline("{0} {1} {2} ", u.firstname, u.lastname, u.email);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EFCarDal());

        //    foreach (var c in carManager.GetCarDetails().Data)
        //    {
        //        Console.WriteLine("{0} {1} {2} {3}", c.CarName, c.BrandName, c.ColorName, c.DailyPrice);
        //    }
        //}

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

        //private static void EFCarDalTest()
        //{
        //    CarManager carManager = new CarManager(new EFCarDal());
        //    foreach (var c in carManager.GetCarsByBrandId(1).Data)
        //    {
        //        Console.WriteLine(c.Description);
        //    }

        //    Console.WriteLine(carManager.GetById(2).Data.CarName);
        //}

        //private static void InMemoryTest()
        //{
        //    CarManager carManager = new CarManager(new InMemoryCarDal());
        //    foreach (var c in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine(c.Description);
        //    }
        //}
    }
}
