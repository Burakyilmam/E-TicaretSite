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
    public class EfProductRepository : GenericRepository<Product>, IProductDal
    {
        public List<Product> ListProductWithCategory()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Where(x=>x.Statu == true).ToList();
            }

        }
        public List<Product> ListNewProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.CreatedDate).Where(x=>(x.CreatedDate <= DateTime.Now) && (x.Statu == true)).ToList();
            }

        }
        public List<Product> ListHighPriceProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.Price).Where(x => x.Statu == true).ToList();
            }

        }
        public List<Product> ListLowPriceProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderBy(x => x.Price).Where(x => x.Statu == true).ToList();
            }

        }
        public List<Product> ListLowStockProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderBy(x => x.Stock).Where(x=>(x.Stock > 0) && (x.Statu == true)).ToList();
            }

        }
        public List<Product> ListHighStockProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.Stock).Where(x => (x.Stock > 0) && (x.Statu == true)).ToList();
            }

        }
    }
}
