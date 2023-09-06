using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListMostViewProducts : ViewComponent
    {
        ProductManager pm = new ProductManager((new EfProductRepository()));
        public IViewComponentResult Invoke()
        {
            var value = pm.ListMostViewProduct().Take(10);
            return View(value);
        }
    }
}
