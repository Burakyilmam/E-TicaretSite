using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListElectronicProducts : ViewComponent
    {
        ProductManager pm = new ProductManager((new EfProductRepository()));
        public IViewComponentResult Invoke()
        {
            var value = pm.ListElectronicProducts();
            return View(value);
        }
    }
}
