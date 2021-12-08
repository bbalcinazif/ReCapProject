using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
            //ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            if(result.Success==true)
            {
                foreach (var cars in result.Data )
                {
                    Console.WriteLine("Araba Adı :" + cars.CarName + " || " +

                                      "Günlük Fiyatı :" + cars.DailyPrice );
                                      
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
