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
    public class ProductAttributeManager : IProductAttributeService
    {
        IProductAttributeDal _productAttributeDal;

        public ProductAttributeManager(IProductAttributeDal productAttributeDal)
        {
            _productAttributeDal = productAttributeDal;
        }
        public void Add(ProductsAttribute t)
        {
            _productAttributeDal.Add(t);
        }

        public void Delete(ProductsAttribute t)
        {
            _productAttributeDal.Delete(t);
        }

        public ProductsAttribute Get(int id)
        {
            return _productAttributeDal.GetId(id);
        }

        public List<ProductsAttribute> List()
        {
            return _productAttributeDal.List();
        }

        public List<ProductsAttribute> ListProductAttributeWithCategory(int id)
        {
            return _productAttributeDal.ListProductAttributeWithCategory(id);
        }

        public void Update(ProductsAttribute t)
        {
            _productAttributeDal.Update(t);
        }
    }
}
