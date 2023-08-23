using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListProductCategory : ViewComponent
    {
        CategoryManager cm = new CategoryManager((new EfCategoryRepository()));
        public IViewComponentResult Invoke()
        {
            DataContext c = new DataContext();
            var value = cm.ListProductCategory()    ;
            return View(value);
        }
    }
}
