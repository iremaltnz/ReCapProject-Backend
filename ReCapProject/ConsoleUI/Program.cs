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

            //EFCarDalTest();

            //ColorTest();

            // BrandTest();

            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} {1} {2} {3}",c.CarName,c.BrandName,c.ColorName,c.DailyPrice);
            }

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());

            foreach (var b in brandManager.GetAll())
            {
                Console.WriteLine("{0} {1}", b.BrandId, b.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var c in colorManager.GetAll())
            {
                Console.WriteLine("{0}  {1}", c.ColorId, c.ColorName);
            }
        }

        private static void EFCarDalTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var c in carManager.GetById(3))
            {
                Console.WriteLine(c.Description);
            }
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
        }
    }
    
}
