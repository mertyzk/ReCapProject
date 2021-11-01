using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System;

namespace ConsoleUITest
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            
            foreach (var car in carManager.GetAll())
            {
                Console.Write(car.CarId);
            }
            Console.WriteLine("");
            foreach (var color in colorManager.GetAll())
            {
                Console.Write(color.ColorName);
            }
            Console.WriteLine("");
            foreach (var brand in brandManager.GetAll())
            {
                Console.Write(brand.BrandName);
            }

            foreach (var desc in carManager.GetAll())
            {
                Console.WriteLine(desc.Description);
            }

            carManager.Add(new Car { ModelYear = 2001, DailyPrice = 254555, Description = "Yeni eklenen ürün", ColorId = 2, BrandId = 1 });



        }
    }
}
