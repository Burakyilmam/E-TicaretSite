using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class BrandCount : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke()
        {
            var brand = c.Brands.Where(x => x.Statu == true).Count();
            ViewBag.BRand = brand;
            return View();
        }
    }
}
