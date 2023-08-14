using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        DataContext c = new DataContext();
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult ProductList()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.Name = username;
                    ViewBag.Id = userId;
                }
            }
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
