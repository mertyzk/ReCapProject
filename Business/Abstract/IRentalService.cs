using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetRentalsByCarId(int carId);
        IDataResult<List<Rental>> GetRentalsByCustomerId(int customerId);
        IDataResult<Rental> GetById(int rentId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

    }
}
