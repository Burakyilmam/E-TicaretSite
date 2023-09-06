using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListMainCategory : ViewComponent
    {
        MainCategoryManager mcm = new MainCategoryManager((new EfMainCategoryRepository()));
        public IViewComponentResult Invoke()
        {
            DataContext c = new DataContext();
            var value = mcm.List();
            return View(value);
        }
    }
}
