using System;
using System.Collections.Generic;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        List<Rental> GetRentalsByCarId(int carId);
        List<Rental> GetRentalsByCustomerId(int customerId);
        Rental GetById(int rentId);
        List<RentalDetailDto> GetRentalDetails();

        public void Add();
        public void Update();
        public void Delete();

    }
}
