﻿using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entity.Entities;
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
                return c.Categories.Where(x => x.Statu == true).OrderBy(x => x.Name).ToList();
            }
        }
    }
}
