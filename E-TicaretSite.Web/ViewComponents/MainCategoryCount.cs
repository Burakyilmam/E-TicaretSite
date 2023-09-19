using Business.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class MainCategoryCount : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke()
        {
            var maincategory = c.MainCategories.Where(x => x.Statu == true).Count();
            ViewBag.MainCategory = maincategory;
            return View();
        }
    }
}
