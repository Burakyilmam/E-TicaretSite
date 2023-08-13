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
    public class EfProductImageRepository : GenericRepository<ProductImage>,IProductImageDal
    {
        public List<ProductImage> ListProductImages(int id)
        {
            using (var c = new DataContext())
            {
                return c.ProductImages.Where(x => (x.Statu == true) && (x.ProductId == id)).ToList();
            }

        }
    }
}
