using System.ComponentModel.DataAnnotations;

namespace E_TicaretSite.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Statu { get; set; }
        public List<Product> Products { get; set; }
    }
}
