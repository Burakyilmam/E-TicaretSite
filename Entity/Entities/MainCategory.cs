using E_TicaretSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class MainCategory : EntityBase
    {
        public string MainCategoryName { get; set; }
        public List<Category> Categories { get; set; }
    }
}
