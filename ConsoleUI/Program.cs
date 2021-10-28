using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUIT
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Numarası : " + car.CarId + " - " + "Araç Fiyatı :" + car.DailyPrice + "TL");
            }


        }
    }
}
