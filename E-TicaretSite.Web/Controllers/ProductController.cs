using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Security.Claims;
using X.PagedList;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        DataContext c = new DataContext();
        ProductManager pm = new ProductManager(new EfProductRepository());
        ProductImageManager pim = new ProductImageManager(new EfProductImageRepository());
        public IActionResult ProductList(string p,int page = 1)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(p))
            {
                if (!string.IsNullOrEmpty(userIdClaim))
                {
                    int userId = int.Parse(userIdClaim);
                    var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                    if (user != null)
                    {
                        var username = User.Identity.Name;
                        ViewBag.UserName = username;
                        ViewBag.Id = userId;
                        return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    return View();
                }
               
            }
            if (!string.IsNullOrEmpty(userIdClaim))
            {
                int userId = int.Parse(userIdClaim);
                var user = c.Users.FirstOrDefault(x => x.Id == userId && x.Statu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.UserName = username;
                    ViewBag.Id = userId;
                    var value = pm.ListProductWith().ToPagedList(page, 10);
                    return View(value);
                }
            }
            
            return View();
        }
        [AllowAnonymous]
        public IActionResult MostViewProduct(string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))).ToPagedList(page,10));
            }
            var value = pm.ListMostViewProduct().ToPagedList(page,10);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListHighPriceProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListHighPriceProduct();
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListLowPriceProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListLowPriceProduct();
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListHighStockProduct(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListHighStockProduct();
            return View(value);
        }
        [AllowAnonymous]
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
        public IActionResult ListCategoryProduct(int id, string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))).ToPagedList(page, 10));
            }
            var value = pm.ListCategoryProduct(id).ToPagedList(page,10);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListBrandProduct(int id, string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))).ToPagedList(page, 10));
            }
            var value = pm.ListBrandProduct(id).ToPagedList(page,10);
            return View(value);
        }
        [AllowAnonymous]
        public IActionResult ListMainCategoryProduct(int id,string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Product/MostViewProduct.cshtml", pm.ListMostViewProduct().Where(x => x.Name.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower())))));
            }
            var value = pm.ListMainCategoryProduct(id).ToPagedList(page,5);
            return View(value);
        }
        [HttpGet]
        public IActionResult ProductAdd()
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
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            product.Statu = true;
            product.CreatedDate = DateTime.Now;
            product.View = 0;
            product.Star = 0;
            pm.Add(product);
            return RedirectToAction("ProductList", "Product");
        }
        public IActionResult ProductDelete(int id)
        {
            var value = pm.Get(id);
            pm.Delete(value);
            TempData["SuccessMessage"] = "Ürün başarıyla silindi.";
            return RedirectToAction("ProductList", "Product");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
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
            }
            return View();
        }
        public IActionResult DetailProduct(int id)
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
            }
            return View();
            
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            pm.Update(product);
            return RedirectToAction("ProductList", "Product");
        }
        public IActionResult GetProductImages(int id,string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pim.GetProductImages(id).Where(x => x.ImageUrl.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
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
                    ViewBag.ProductId = id;
                    var productimages = pim.GetProductImages(id).ToPagedList(page, 10);
                    return View(productimages);
                }
            }
            return View();   
        }
        public IActionResult ProductImagesSortIdOrderBy(int id,string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pim.GetProductImages(id).Where(x => x.ImageUrl.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pim.GetProductImages(id).OrderBy(x => x.Id).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult ProductImagesSortIdOrderByDescending(int id, string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pim.GetProductImages(id).Where(x => x.ImageUrl.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pim.GetProductImages(id).OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult ProductImagesSortStatuOrderBy(int id, string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pim.GetProductImages(id).Where(x => x.ImageUrl.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pim.GetProductImages(id).OrderBy(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult ProductImagesSortStatuOrderByDescending(int id,string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pim.GetProductImages(id).Where(x => x.ImageUrl.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pim.GetProductImages(id).OrderByDescending(x => x.Statu).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult ProductImagesSortDateOrderBy(int id, string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pim.GetProductImages(id).Where(x => x.ImageUrl.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pim.GetProductImages(id).OrderBy(x => x.CreatedDate).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult ProductImagesSortDateOrderByDescending(int id, string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pim.GetProductImages(id).Where(x => x.ImageUrl.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pim.GetProductImages(id).OrderByDescending(x => x.CreatedDate).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortIdOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderBy(x => x.Id).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult SortIdOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderBy(x => x.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderByDescending(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderByDescending(x => x.Name).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult SortBrandOrderBy(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderBy(x => x.Brand.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortBrandOrderByDescending(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderByDescending(x => x.Brand.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortPriceOrderBy(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderBy(x => x.Price).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortPriceOrderByDescending(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderByDescending(x => x.Price).ToPagedList(page, 10); ;
            return View(value);
        }

        public IActionResult SortStockOrderBy(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderBy(x => x.Stock).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortStockOrderByDescending(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderByDescending(x => x.Stock).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortCategoryOrderBy(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderBy(x => x.Category.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortCategoryOrderByDescending(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderByDescending(x => x.Category.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortStatuOrderBy(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortStatuOrderByDescending(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.ListProductWith().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = pm.ListProductWith().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
    }
}
