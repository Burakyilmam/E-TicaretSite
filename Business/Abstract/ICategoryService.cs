using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public List<Category> ListProductCategory();
        List<Category> GetCategory(int id);
        bool CheckCategoryName(string CategoryName);
    }
}
