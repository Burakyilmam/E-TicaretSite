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

        public void Add(Category t)
        {
            _categoryDal.Add(t);
        }

        public bool CheckCategoryName(string CategoryName)
        {
            return _categoryDal.CheckCategoryName(CategoryName);
        }

        public void Delete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category Get(int id)
        {
            return _categoryDal.GetId(id);
        }

        public List<Category> GetCategory(int id)
        {
            return _categoryDal.GetCategory(id);
        }

        public List<Category> List()
        {
            return _categoryDal.List();
        }

        public List<Category> ListProductCategory()
        {
            return _categoryDal.ListProductCategory();
        }

        public void Update(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
