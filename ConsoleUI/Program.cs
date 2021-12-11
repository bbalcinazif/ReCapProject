using Business.Concrete;
using Business.Constants;
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
            //CarTest();
            //BrandTest();
            //ColorTest();

            Rentals();

        }

        private static void Rentals()
        {
            RentalsManager rentalsManager = new RentalsManager(new EfRentalsDal());
            var result = rentalsManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rentals in result.Data)
                {
                    Console.WriteLine("Kiralama ID:" + rentals.RentalId + "Kullanıcı ID:" + rentals.CustomerId + "Araba ID:" + rentals.CarId);
                }
            }
            else
            {
                Console.WriteLine(Messages.Error);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if(result.Success==true)
            {
                foreach (var colors in result.Data)
                {
                    Console.WriteLine(" Renk Adı: "+ colors.ColorName + " Renk Id'si: " +colors.ColorId);
                }
            }
            else
            {
                Console.WriteLine(Messages.Error);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if(result.Success==true)
            {
                foreach (var brands in result.Data)
                {
                    Console.WriteLine(" Marka Adı: " + brands.BrandName + " Marka Id'si " + brands.BrandId);
                }
            }
            else
            {
                Console.WriteLine(Messages.Error);
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
