using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetProductDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cars
                             join a in context.Colors
                             on c.ColorId equals a.ColorId
                             select new CarDetailDto { CarName = c.CarName, 
                                 ColorName = a.ColorName, DailyPrice = c.DailyPrice, BrandName = c.Description };

                return result.ToList();
            }
            
        }
    }
}
