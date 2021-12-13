using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfDescriptionExist(car.Description),
                CheckIfCarCountOfBrandCorrect(car.BrandId),
                CheckIfBrandLimitExceded());
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.AddedMsg);
        }
         
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedMsg);
        }

        [CacheAspect] //key , value
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedMsg);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedMsg);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result>10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfDescriptionExist(string desc) // Aynı açıklamayla ürün eklenemez. Uydurma kural.
        {
            var result = _carDal.GetAll(c => c.Description == desc).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarDescriptionAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded() // Kategori sayısı 33'ten fazlaysa, yeni ürün ekleme. Uydurma kural.
        {
            var result = _brandService.GetAll(); // Buradaki amaç farklı bir servise ulaşmanın yöntemini öğrenmek. Brand'ta yapılacak işlemi, Car'da çalıştırmak.
            if (result.Data.Count>33) // BURADA BİR INJECTION İŞLEMİ MEVCUT.
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();
        }

    }

}
