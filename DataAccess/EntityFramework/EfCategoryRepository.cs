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
    public class EfCategoryRepository : GenericRepository<Category>,ICategoryDal
    {
        public List<Category> ListProductCategory()
        {
            using (var c = new DataContext())
            {
                return c.Categories.Include(x=>x.MainCategory).OrderBy(x => x.Name).ToList();
            }
        }
        public List<Category> GetCategory(int id)
        {
            using (var c = new DataContext())
            {
                return c.Categories.Include(x => x.MainCategory).Where(x => (x.Statu == true) && (x.MainCategoryId == id)).ToList();
            }
        }
        public bool CheckCategoryName(string CategoryName)
        {
            using (var c = new DataContext())
            {
                var value = c.Categories.Any(a => a.Name == CategoryName);
                return value;
            }
        }
    }
}
