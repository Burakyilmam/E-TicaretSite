using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }  
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
        public bool Statu { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
