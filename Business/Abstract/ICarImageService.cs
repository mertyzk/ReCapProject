using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult <List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);

    }
}
