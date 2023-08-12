using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Adı Boş Bırakılamaz.")]
        [Display(Name = "Adı")]
        [StringLength(50, ErrorMessage = "Adı Maksimum 50 Karakter Olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = " Soyadı Boş Bırakılamaz.")]
        [Display(Name = "Soyadı")]
        [StringLength(100, ErrorMessage = "Soyadı Maksimum 100 Karakter Olmalıdır.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(150, ErrorMessage = "Kullanıcı Adı Maksimum 150 Karakter Olmalıdır.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mail Adresi Boş Bırakılamaz.")]
        [Display(Name = "Mail Adresi")]
        [StringLength(250, ErrorMessage = "Mail Adresi Maksimum 250 Karakter Olmalıdır.")]
        [EmailAddress(ErrorMessage = "Mail Formatında Yazınız.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola Boş Bırakılamaz.")]
        [Display(Name = "Parola")]
        [StringLength(150, ErrorMessage = "Parola Maksimum 150 Karakter Olmalıdır.")]
        [DataType(DataType.Password)]  
        public string Password { get; set; }
        [Required(ErrorMessage = "Parola Tekrar Boş Bırakılamaz.")]
        [Display(Name = "Parola Tekrar")]
        [StringLength(150, ErrorMessage = "Parola Tekrar Maksimum 150 Karakter Olmalıdır.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor.")]
        public string RePassword { get; set; }
        public bool Statu { get; set; }
        public string Role { get; set; }

    }
}
