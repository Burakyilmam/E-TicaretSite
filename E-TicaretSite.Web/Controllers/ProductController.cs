using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        DataContext c = new DataContext();
        ProductManager pm = new ProductManager(new EfProductRepository());
        ProductImageManager pim = new ProductImageManager(new EfProductImageRepository());
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
        public IActionResult MostViewProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListMostViewProduct();
            return View(value);
        }
        public IActionResult ListHighPriceProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListHighPriceProduct();
            return View(value);
        }
        public IActionResult ListLowPriceProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListLowPriceProduct();
            return View(value);
        }
        public IActionResult ListHighStockProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListHighStockProduct();
            return View(value);
        }
        public IActionResult ListLowStockProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListLowStockProduct();
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ProductPage(int id, string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var view = pm.Get(id);

            if (view != null)
            {
                view.View++;
                pm.Update(view);
            }
            ViewBag.Id = id;
            var value = pm.ProductPage(id);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListCategoryProduct(int id, string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListCategoryProduct(id);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListBrandProduct(int id, string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListBrandProduct(id);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListMainCategoryProduct(int id,string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListMainCategoryProduct(id);
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
            product.View = 0;
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
        public IActionResult GetProductImages(int productid)
        {
            var productimages = pim.GetProductImages(productid);
            return View(productimages);
        }
    }
}
