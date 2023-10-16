using E_TicaretSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ProductsAttribute : EntityBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
