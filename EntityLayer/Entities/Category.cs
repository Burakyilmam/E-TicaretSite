using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori Adı Boş Bırakılamaz.")]
        [Display(Name = "Kategori Adı")]
        [StringLength(50,ErrorMessage ="Kategori Adı Maksimum 50 Karakter Olmalıdır.")]
        public string Name { get; set; }
        public bool Statu { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
