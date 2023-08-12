using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager()
        {
           
        }

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Add(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetCategory(int id)
        {
            return _categoryDal.GetId(id);
        }

        public List<Category> ListCategory()
        {
            return _categoryDal.List();
        }
    }
}
