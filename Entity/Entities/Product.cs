using E_TicaretSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public string ThumbnailImage { get; set; }
        public int View { get; set; }
        public int Star { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Comment> Comments{ get; set; }
        public List<CartItems> CartItems { get; set; }
    }
}
