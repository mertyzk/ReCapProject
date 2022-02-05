using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapProjectContext>, ICarDal
    {

        // buraya ürüne ait özel operasyonlar. örneğin join atmak.
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RecapProjectContext context = new RecapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors 
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto {CarId=c.CarId,BrandName=b.BrandName,ColorName=cl.ColorName,DailyPrice=c.DailyPrice, BrandId=b.BrandId, ColorId=c.ColorId, ModelYear=c.ModelYear,Description=c.Description};
               return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
