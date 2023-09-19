using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ProductCount : ViewComponent
    {
        DataContext c = new DataContext();
        public IViewComponentResult Invoke()
        {
            var product = c.Products.Where(x => x.Statu == true).Count();
            ViewBag.Product = product;
            return View();
        }
    }
}
