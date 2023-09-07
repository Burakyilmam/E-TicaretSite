using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.ViewComponents
{
    public class ListBrandProducts : ViewComponent
    {
        ProductManager pm = new ProductManager((new EfProductRepository()));
        public IViewComponentResult Invoke(int id)
        {
            var brandproducts = pm.ListBrandProducts(id);
            return View(brandproducts);
        }
    }
}
