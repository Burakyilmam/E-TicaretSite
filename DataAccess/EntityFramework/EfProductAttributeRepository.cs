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
    public class EfProductAttributeRepository : GenericRepository<ProductsAttribute>, IProductAttributeDal
    {
        public List<ProductsAttribute> ListProductAttributeWithCategory(int id)
        {
            using (var c = new DataContext())
            {
                return c.ProductAttributes.Include(x=>x.Category).Where(x=>x.CategoryId == id).ToList();
            }
        }
    }
}
