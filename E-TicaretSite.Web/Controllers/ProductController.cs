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
            var value = pm.ListProductWithCategory();
            return View(value);
        }
        public IActionResult ProductPage(int id)
        {
            var value = pm.ProductPage(id);
            return View(value);
        }
        public IActionResult ListCategoryProduct(int id)
        {
            var value = pm.ListCategoryProduct(id);
            return View(value);
        }
    }
}
