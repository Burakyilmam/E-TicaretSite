using Business.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MainCategoryManager : IMainCategoryService
    {
        IMainCategoryDal _mainCategoryDal;

        public MainCategoryManager(IMainCategoryDal mainCategoryDal)
        {
            _mainCategoryDal = mainCategoryDal;
        }

        public void Add(MainCategory t)
        {
            _mainCategoryDal.Add(t);
        }

        public bool CheckMainCategoryName(string MainCategoryName)
        {
            return _mainCategoryDal.CheckMainCategoryName(MainCategoryName);
        }

        public void Delete(MainCategory t)
        {
            _mainCategoryDal.Delete(t);
        }

        public MainCategory Get(int id)
        {
            return _mainCategoryDal.GetId(id);
        }

        public List<MainCategory> List()
        {
            return _mainCategoryDal.List();
        }

        public void Update(MainCategory t)
        {
            _mainCategoryDal.Update(t);
        }
    }
}
