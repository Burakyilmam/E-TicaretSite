using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretSite.Core.Entities
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual bool Statu { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
