using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfMainCategoryRepository : GenericRepository<MainCategory>, IMainCategoryDal
    {
        public bool CheckMainCategoryName(string MainCategoryName)
        {
            using (var c = new DataContext())
            {
                var value = c.MainCategories.Any(a => a.MainCategoryName == MainCategoryName);
                return value;
            }
        }
    }
}
