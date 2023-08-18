using E_TicaretSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Cart : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public List<CartItems> CartItems { get; set; }
    }
}
