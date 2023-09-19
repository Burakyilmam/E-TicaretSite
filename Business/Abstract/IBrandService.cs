using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService : IGenericService<Brand>
    {
        public List<Brand> ListProductBrand();
        bool CheckBrandName(string BrandName);
    }
}
