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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> ListBrandProduct(int id)
        {
            return _productDal.ListBrandProduct(id);
        }

        public List<Product> ListCategoryProduct(int id)
        {
            return _productDal.ListCategoryProduct(id);
        }

        public List<Product> ListHighPriceProduct()
        {
            return _productDal.ListHighPriceProduct();
        }

        public List<Product> ListHighStockProduct()
        {
            return (_productDal.ListHighStockProduct());
        }

        public List<Product> ListLowPriceProduct()
        {
           return _productDal.ListLowPriceProduct();
        }

        public List<Product> ListLowStockProduct()
        {
            return _productDal.ListLowStockProduct();
        }

        public List<Product> ListNewProduct()
        {
            return _productDal.ListNewProduct();
        }

        public List<Product> ListProduct()
        {
            return _productDal.List();
        }

        public List<Product> ListProductWithCategory()
        {
            return _productDal.ListProductWithCategory();
        }

        public void ProductAdd(Product product)
        {
            throw new NotImplementedException();
        }

        public void ProductDelete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> ProductPage(int id)
        {
           return _productDal.ProductPage(id);
        }

        public void ProductUpdate(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
