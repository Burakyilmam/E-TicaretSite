using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMainCategoryDal : IGenericDal<MainCategory>
    {
        bool CheckMainCategoryName(string MainCategoryName);
    }
}
