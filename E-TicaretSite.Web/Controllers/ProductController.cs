using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {        
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult ProductList()
        {
            var value = pm.ListProductWith();
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ProductPage(int id)
        {
            ViewBag.Id = id;
            var value = pm.ProductPage(id);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListCategoryProduct(int id)
        {
            var value = pm.ListCategoryProduct(id);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListBrandProduct(int id)
        {
            var value = pm.ListBrandProduct(id);
            return View(value);
        }
    }
}
