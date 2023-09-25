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
        public ProductManager()
        {

        }

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product t)
        {
            _productDal.Add(t);
        }

        public void Delete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product Get(int id)
        {
            return _productDal.GetId(id);
        }

        public List<Product> ListProductWith()
        {
            return _productDal.ListProductWith();
        }

        public List<Product> ListBrandProduct(int id)
        {
            return _productDal.ListBrandProduct(id);
        }

        public List<Product> ListCategoryProduct(int id)
        {
            return _productDal.ListCategoryProduct(id);
        }

        public List<Product> ListElectronicProducts()
        {
            return _productDal.ListElectronicProducts();
        }

        public List<Product> ListHighPriceProduct()
        {
            return _productDal.ListHighPriceProduct();
        }

        public List<Product> ListHighStockProduct()
        {
            return _productDal.ListHighStockProduct();
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

        public List<Product> ProductPage(int id)
        {
            return _productDal.ProductPage(id);
        }

        public void Update(Product t)
        {
            _productDal.Update(t);
        }
        public List<Product> ListCommentProduct()
        {
            return _productDal.ListCommentProduct();
        }

        public List<Product> ListMostViewProduct()
        {
            return _productDal.ListMostViewProduct();
        }

        public List<Product> ListMainCategoryProduct(int id)
        {
            return _productDal.ListMainCategoryProduct(id);
        }

        public List<Product> ListClothingProducts()
        {
            return _productDal.ListClothingProducts();
        }

        public List<Product> ListSimilarCategoryProduct(int id)
        {
            return _productDal.ListSimilarCategoryProduct(id);
        }

        public List<Product> ListBrandProducts(int id)
        {
            return _productDal.ListBrandProducts(id);
        }

        public List<Product> MainCategoryProducts(int id)
        {
            return _productDal.MainCategoryProducts(id);
        }

        public List<Product> ListStationaryProducts()
        {
            return _productDal.ListStationaryProducts();
        }

        public List<Product> List()
        {
            return _productDal.List();
        }

        public List<Product> GetProduct(int id)
        {
            return _productDal.GetProduct(id);
        }

        public List<Product> GetBrandProduct(int id)
        {
            return _productDal.GetBrandProduct(id);
        }
    }
}
