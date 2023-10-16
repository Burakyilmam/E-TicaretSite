using E_TicaretSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductsAttribute> productsAttributes { get; set; }

    }
}
