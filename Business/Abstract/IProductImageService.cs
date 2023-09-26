using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService : IGenericService<ProductImage>
    {
        List<ProductImage> ListProductImages(int id);
        List<ProductImage> GetProductImages(int id);
        bool CheckProductImageUrl(string Url);
    }
}
