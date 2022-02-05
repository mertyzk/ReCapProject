using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IResult AddTransactionalTest(Car car);
    }
}
