using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        DataContext c = new DataContext();
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult ProductList(Product product)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.UserName = username;
                    ViewBag.Id = userId;
                }
            }
            var value = pm.ListProductWith();
            return View(value);
        }
        public void UpdateProductStatus()
        {
            var productsWithZeroStock = pm.ListProductWith().Where(p => p.Stock == 0).ToList();

            foreach (var product in productsWithZeroStock)
            {
                product.Statu = false;
                pm.Update(product);
            }
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
        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            product.Statu = true;
            product.CreatedDate = DateTime.Now;
            pm.Add(product);
            return RedirectToAction("ProductList", "Product");
        }
        public IActionResult ProductDelete(int id)
        {
            var value = pm.Get(id);
            pm.Delete(value);
            return RedirectToAction("ProductList", "Product");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            BrandManager bm = new BrandManager(new EfBrandRepository());

            var categories = cm.List();
            var brands = bm.List();

            var categoryItems = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            var branditems = brands.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            ViewBag.Categories = categoryItems;
            ViewBag.Brands = branditems;
            var value = pm.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            pm.Update(product);
            return RedirectToAction("ProductList", "Product");
        }
    }
}
