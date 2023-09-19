using Business.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand t)
        {
            _brandDal.Add(t);
        }

        public bool CheckBrandName(string BrandName)
        {
            return _brandDal.CheckBrandName(BrandName);
        }

        public void Delete(Brand t)
        {
            _brandDal.Delete(t);
        }

        public Brand Get(int id)
        {
            return _brandDal.GetId(id);
        }

        public List<Brand> List()
        {
           return _brandDal.List();
        }

        public List<Brand> ListProductBrand()
        {
            return _brandDal.ListProductBrand();
        }

        public void Update(Brand t)
        {
            _brandDal.Update(t);
        }
    }
}
