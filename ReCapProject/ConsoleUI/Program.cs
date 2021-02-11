using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();

            EFCarDalTest();

           // ColorTest();

           //  BrandTest();

           // CarTest();

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
