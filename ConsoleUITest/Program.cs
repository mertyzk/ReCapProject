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
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }




            //DbSonucDondurme(brandManager, colorManager);

            // ForeachListeletme(carManager, brandManager, colorManager);


            //EKLEME ID ISTEMEZ.IDENTITY'DIR OTOMATIK ARTAR PRIMARY KEY.
            //carManager.Add(new Car { ModelYear = 2017, DailyPrice = 320, Description = "Insignia", ColorId = 10, BrandId = 17 });

            //GÜNCELLEME VE DELETE ID ISTER.O ürünü bulabilmek için.

            //carManager.Delete(new Car { CarId = 1 });

            //carManager.Update(new Car { CarId = 3, ModelYear = 2222, DailyPrice = 1231235, Description = "Güncellenen ürün", ColorId = 1, BrandId = 2 });


        }

        //#region DBSonucDondurme
        //private static void DbSonucDondurme(BrandManager brandManager, ColorManager colorManager)
        //{
        //    Console.WriteLine("1 ile 12 arasında bir marka seçiniz");
        //    int selectBrand = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine(brandManager.GetById(selectBrand));

        //    Console.WriteLine("1 ile 7 arasında bir renk seçiniz");
        //    int selectColor = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine(colorManager.GetById(selectColor));
        //}
        //#endregion

        //#region ForeachListeletme
        //private static void ForeachListeletme(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        //{
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.Write(car.CarId + "\n");
        //    }
        //    Console.WriteLine("");
        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.Write(color.ColorName + "\n");
        //    }
        //    Console.WriteLine("");
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.Write(brand.BrandName + "\n");
        //    }
        //}
        //#endregion
    }
}
