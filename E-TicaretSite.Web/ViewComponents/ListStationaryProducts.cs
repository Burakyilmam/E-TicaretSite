using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListStationaryProducts : ViewComponent
    {
        ProductManager pm = new ProductManager((new EfProductRepository()));
        public IViewComponentResult Invoke()
        {
            var value = pm.ListStationaryProducts();
            return View(value);
        }
    }
}
