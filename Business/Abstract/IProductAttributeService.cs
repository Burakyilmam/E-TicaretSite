using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductAttributeService : IGenericService<ProductsAttribute>
    {
        List<ProductsAttribute> ListProductAttributeWithCategory(int id);
    }
}
