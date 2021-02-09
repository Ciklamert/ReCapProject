using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        

        List<CarDetailDto> ICarDal.GetCarDetailDtos()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from ca in context.Cars join b in context.Brands on ca.BrandId equals b.BrandId join co in context.Colors on ca.ColorId equals co.ColorId select new CarDetailDto 
                { Description = ca.Description, DailyPrice = ca.DailyPrice, BrandName = b.BrandName, ColorName = co.ColorName };



                return result.ToList();
            
            }
        }
    }
}
