using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListProductImages : ViewComponent
    {
        ProductImageManager pm = new ProductImageManager((new EfProductImageRepository()));
        public IViewComponentResult Invoke(int id)
        {
            var value = pm.ListProductImages(id);
            return View(value);
        }
    }
}
