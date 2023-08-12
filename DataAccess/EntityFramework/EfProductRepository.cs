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
                return c.Products.Include(x => x.Category).ToList();
            }

        }
        public List<Product> ListNewProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.CreatedDate).ToList();
            }

        }
        public List<Product> ListHighPriceProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.Price).ToList();
            }

        }
        public List<Product> ListLowPriceProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderBy(x => x.Price).ToList();
            }

        }
        public List<Product> ListLowStockProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderBy(x => x.Stock).ToList();
            }

        }
        public List<Product> ListHighStockProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.Stock).ToList();
            }

        }
    }
}
