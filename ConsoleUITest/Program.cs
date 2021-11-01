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

            Console.WriteLine("1 ile 12 arasında bir marka seçiniz");
            int selectBrand = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(brandManager.GetById(selectBrand).BrandName);

            Console.WriteLine("1 ile 7 arasında bir renk seçiniz");
            int selectColor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(colorManager.GetById(selectColor).ColorName);



            //foreach (var car in carManager.GetAll())
            //{
            //    Console.Write(car.CarId + "\n");
            //}
            //Console.WriteLine("");
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.Write(color.ColorName+"\n");
            //}
            //Console.WriteLine("");
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.Write(brand.BrandName + "\n");
            //}


            //EKLEME ID ISTEMEZ. IDENTITY'DIR OTOMATIK ARTAR PRIMARY KEY.
            // carManager.Add(new Car { ModelYear = 2001, DailyPrice = 254555, Description = "Yeni eklenen ürün", ColorId = 2, BrandId = 1 });

            // GÜNCELLEME VE DELETE ID ISTER. O ürünü bulabilmek için.

            //carManager.Delete(new Car { CarId = 8});

            // carManager.Update(new Car { CarId = 3, ModelYear = 2222, DailyPrice = 1231235, Description = "Güncellenen ürün", ColorId = 1, BrandId = 2 });


        }
    }
}
