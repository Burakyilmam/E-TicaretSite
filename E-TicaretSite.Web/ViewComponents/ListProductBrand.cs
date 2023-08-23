using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListProductBrand : ViewComponent
    {
        BrandManager bm = new BrandManager((new EfBrandRepository()));
        public IViewComponentResult Invoke()
        {
            DataContext c = new DataContext();
            var value = bm.ListProductBrand();
            return View(value);
        }
    }
}
