using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Results;
using Business.Constans;
using Core.CrossCuttingConcers.Validation.FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Microsoft.AspNetCore.Authorization;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.AddedMsg);
        
        }

        public IResult Delete(Brand brand)
        { 

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.DeletedMsg);
        }

    
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Brand>>(_brandDal.GetAll(),Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {

            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult( Messages.UpdatedMsg);
        }
    }
}
