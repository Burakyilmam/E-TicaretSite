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
        [Required(ErrorMessage = "Ürün Adı Boş Bırakılamaz.")]
        [Display(Name = "Ürün Adı")]
        [StringLength(250, ErrorMessage = "Ürün Adı Maksimum 250 Karakter Olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ürün Açıklaması Boş Bırakılamaz.")]
        [Display(Name = "Ürün Açıklaması")]
        [StringLength(500, ErrorMessage = "Ürün Açıklaması Maksimum 500 Karakter Olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ürün Resim Url Boş Bırakılamaz.")]
        [Display(Name = "Ürün Resim Url")]
        [StringLength(500, ErrorMessage = "Ürün Resim Url Maksimum 500 Karakter Olmalıdır.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Ürün Fiyatı Boş Bırakılamaz.")]
        [Display(Name = "Ürün Fiyatı")]    
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Ürün Stok Bilgisi Boş Bırakılamaz.")]
        [Display(Name = "Ürün Stok")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Ürün Sayısı Boş Bırakılamaz.")]
        [Display(Name = "Ürün Sayısı")]
        public int Quantity { get; set; }
        public bool Statu { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
