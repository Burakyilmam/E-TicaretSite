using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfProductImageRepository : GenericRepository<ProductImage>,IProductImageDal
    {
        public List<ProductImage> ListProductImages(int id)
        {
            using (var c = new DataContext())
            {
                return c.ProductImages.Where(x => (x.Statu == true) && (x.ProductId == id)).ToList();
            }
        }
        public List<ProductImage> GetProductImages(int id)
        {
            using (var c = new DataContext())
            {
                return c.ProductImages.Include(x=>x.Product).Where(x =>(x.ProductId == id)).ToList();
            }
        }
        public bool CheckProductImageUrl(string Url)
        {
            using (var c = new DataContext())
            {
                var value = c.ProductImages.Any(a => a.ImageUrl == Url);
                return value;
            }
        }
    }
}
