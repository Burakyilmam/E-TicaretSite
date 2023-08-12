using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult ProductList()
        {
            var value = pm.ListHighStockProduct();
            return View(value);
        }
    }
}
