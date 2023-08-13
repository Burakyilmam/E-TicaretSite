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

        public ProductImage GetProductImage(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductImage> ListProductImage()
        {
            throw new NotImplementedException();
        }

        public List<ProductImage> ListProductImages(int id)
        {
            return _productImageDal.ListProductImages(id);
        }

        public void ProductImageAdd(ProductImage productImage)
        {
            throw new NotImplementedException();
        }

        public void ProductImageDelete(ProductImage productImage)
        {
            throw new NotImplementedException();
        }

        public void ProductImageUpdate(ProductImage productImage)
        {
            throw new NotImplementedException();
        }
    }
}
