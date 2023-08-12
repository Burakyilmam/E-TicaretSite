using System.ComponentModel.DataAnnotations;

namespace E_TicaretSite.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public bool Statu { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
