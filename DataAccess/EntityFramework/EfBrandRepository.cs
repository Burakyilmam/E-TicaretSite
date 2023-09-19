using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBrandRepository : GenericRepository<Brand>, IBrandDal
    {
        public List<Brand> ListProductBrand()
        {
            using (var c = new DataContext())
            {
                return c.Brands.Where(x => x.Statu == true).OrderBy(x => x.Name).ToList();
            }
        }
        public bool CheckBrandName(string BrandName)
        {
            using (var c = new DataContext())
            {
                var value = c.Brands.Any(a => a.Name == BrandName);
                return value;
            }
        }
    }
}
