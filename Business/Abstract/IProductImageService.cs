using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        void ProductImageAdd(ProductImage productImage);
        void ProductImageDelete(ProductImage productImage);
        void ProductImageUpdate(ProductImage productImage);
        ProductImage GetProductImage(int id);
        List<ProductImage> ListProductImage();
        List<ProductImage> ListProductImages(int id);
    }
}
