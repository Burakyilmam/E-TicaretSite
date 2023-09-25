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
        public List<Product> ListProductWith()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand)./*Where(x=>x.Statu == true).*/ToList();
            }

        }
        public List<Product> ListNewProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.CreatedDate).Where(x => (x.CreatedDate <= DateTime.Now) && (x.Statu == true)).ToList();
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
                return c.Products.Include(x => x.Category).OrderBy(x => x.Stock).Where(x => (x.Stock > 0) && (x.Statu == true)).ToList();
            }

        }
        public List<Product> ListHighStockProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.Stock).Where(x => (x.Stock > 0) && (x.Statu == true)).ToList();
            }

        }
        public List<Product> ListCategoryProduct(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).OrderByDescending(x => x.CreatedDate).Where(x => (x.CategoryId == id) && (x.Statu == true)).ToList();
            }
        }
        public List<Product> ListBrandProduct(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).OrderByDescending(x => x.CreatedDate).Where(x => (x.BrandId == id) && (x.Statu == true)).ToList();
            }

        }
        public List<Product> ListMainCategoryProduct(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).OrderByDescending(x => x.CreatedDate).Where(x => (x.Category.MainCategoryId == id) && (x.Statu == true)).ToList();
            }

        }
        public List<Product> ProductPage(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).Include(x=>x.Category.MainCategory).Where(x => x.Id == id).ToList();
            }

        }
        public List<Product> ListElectronicProducts()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).Where(x => x.Category.MainCategoryId == 1).Take(10).ToList();
            }
        }
        public List<Product> MainCategoryProducts(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).Where(x => x.Category.MainCategoryId == id).Take(10).ToList();
            }
        }
        public List<Product> ListClothingProducts()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).Where(x => x.Category.MainCategoryId == 2).Take(10).ToList();
            }
        }
        public List<Product> ListStationaryProducts()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).Where(x => x.Category.MainCategoryId == 6).Take(10).ToList();
            }
        }
        
        public List<Product> ListMostViewProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).OrderByDescending(x => x.View).Take(10).ToList();
            }
        }
        public List<Product> ListCommentProduct()
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).Where(x => x.Statu == true).OrderBy(x => x.Name).ToList();
            }
        }
        public List<Product> ListSimilarCategoryProduct(int id)
        {
            using(var c = new DataContext())
            {
                return c.Products.Include(x=>x.Category).Include(x=>x.Brand).OrderByDescending(x => x.View).Where(x => (x.CategoryId == id) && (x.Statu == true)).ToList();
            }
        }
        public List<Product> ListBrandProducts(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).OrderByDescending(x => x.View).Where(x => (x.BrandId == id) && (x.Statu == true)).ToList();
            }
        }
        public List<Product> GetProduct(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x=>x.Brand).Where(x => (x.Statu == true) && (x.CategoryId == id)).ToList();
            }
        }
        public List<Product> GetBrandProduct(int id)
        {
            using (var c = new DataContext())
            {
                return c.Products.Include(x => x.Category).Include(x => x.Brand).OrderByDescending(x => x.CreatedDate).Where(x => (x.BrandId == id) && (x.Statu == true)).ToList();
            }
        }
    }
}
