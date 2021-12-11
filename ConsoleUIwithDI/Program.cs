using System;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUIwithDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRentalsDal, EfRentalsDal>()
                .AddSingleton<ICustomerDal, EfCustomerDal>()
                .AddSingleton<ICarDal, EfCarDal>()
                .AddSingleton<IBrandDal, EfBrandDal>()
                .AddSingleton<IColorDal, EfColorDal>()
                .AddSingleton<IUserDal, EfUserDal>();

            serviceProvider.AddDbContextPool<CarProjectContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=Cars;User Id=sa;Password=Mb123456,");
            });

            var build = serviceProvider.BuildServiceProvider();

            var brandDal = build.GetRequiredService<IBrandDal>();

            brandDal.GetAll();

            Console.WriteLine("Hello World!");
        }
    }
}