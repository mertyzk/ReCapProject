using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUITest
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("CAR ID: "+ car.CarId + "\nAÇIKLAMA : "+ car.Description +"\nAraç Fiyatı: " + car.DailyPrice + "TL\n");

            }
        }
    }
}
