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
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public void Add(ProductImage t)
        {
            _productImageDal.Add(t);
        }

        public bool CheckProductImageUrl(string Url)
        {
            return _productImageDal.CheckProductImageUrl(Url);
        }

        public void Delete(ProductImage t)
        {
            _productImageDal.Delete(t);
        }

        public ProductImage Get(int id)
        {
            return _productImageDal.GetId(id);
        }

        public List<ProductImage> GetProductImages(int id)
        {
            return _productImageDal.GetProductImages(id);
        }

        public List<ProductImage> List()
        {
           return _productImageDal.List();
        }

        public List<ProductImage> ListProductImages(int id)
        {
            return _productImageDal.ListProductImages(id);
        }

        public void Update(ProductImage t)
        {
            _productImageDal.Update(t);
        }
    }
}
