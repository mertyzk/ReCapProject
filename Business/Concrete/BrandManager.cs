using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            // CRUD = Create = add , Read = GetAll,GetBy ID vs , Update / delete
      
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
            }
        }

        public void Delete(Brand brand)
        { 

            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            
            return _brandDal.Get(b=>b.BrandId==brandId);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
