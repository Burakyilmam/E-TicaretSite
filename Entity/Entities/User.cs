using E_TicaretSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Cart> Carts { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
