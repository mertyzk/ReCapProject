using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            
                new Car{BrandId=1,CarId=1,ColorId=1,DailyPrice=150000,Description="A180",ModelYear=2008 },
                new Car{BrandId=1,CarId=2,ColorId=2,DailyPrice=450000,Description="E250",ModelYear=2016 },
                new Car{BrandId=2,CarId=3,ColorId=4,DailyPrice=280000,Description="316i",ModelYear=2015 },
                new Car{BrandId=3,CarId=4,ColorId=1,DailyPrice=850000,Description="A8",ModelYear=2019 },
                new Car{BrandId=4,CarId=5,ColorId=3,DailyPrice=330000,Description="PASSAT",ModelYear=2019 },

            };
            
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        //Car IEntityRepository<Car>.GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
