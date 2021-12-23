using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapProjectContext context = new RecapProjectContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join cu in context.Customers
                             on re.CustomerId equals cu.CustomerId
                             join us in context.Users
                             on cu.UserId equals us.UserId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId

                             select new RentalDetailDto { RentId = re.RentId, BrandId = br.BrandId, BrandName = br.BrandName, CarId = ca.CarId, ColorId = co.ColorId, ColorName = co.ColorName, CompanyName = cu.CompanyName, CustomerId = cu.CustomerId, UserId = us.UserId, FirstName=us.FirstName, LastName=us.LastName };
                return result.ToList();
            }
        }
    }
}
