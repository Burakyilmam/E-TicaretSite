using System.ComponentModel.DataAnnotations;

namespace E_TicaretSite.Models
{
    public class User
    {
        [Key]
        public string Id { get; init; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Statu { get; set; }
    }
