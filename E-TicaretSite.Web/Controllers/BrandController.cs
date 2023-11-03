using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using X.PagedList;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        DataContext c = new DataContext();
        BrandManager bm = new BrandManager(new EfBrandRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult BrandList(string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(bm.List().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = bm.List().ToPagedList(page, 10);
            return View(value);
        }
        [HttpGet]
        public IActionResult BrandAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BrandAdd(Brand brand)
        {
            bool isBrandExist = bm.CheckBrandName(brand.Name);
            if (!isBrandExist)
            {
                brand.Statu = true;
                brand.CreatedDate = DateTime.Now;
                bm.Add(brand);
                return RedirectToAction("BrandList", "Brand");
            }
            else
            {
                TempData["ErrorMessage"] = "Marka Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Marka Adı Yazınız.";
                return RedirectToAction("BrandList");
            }
            
        }
        public IActionResult BrandDelete(int id)
        {
            var value = bm.Get(id);
            bm.Delete(value);
            TempData["SuccessMessage"] = "Marka başarıyla silindi.";
            return RedirectToAction("BrandList", "Brand");
        }
        [HttpGet]
        public IActionResult EditBrand(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = bm.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditBrand(Brand brand)
        {
            bm.Update(brand);
            return RedirectToAction("BrandList", "Brand");
        }
        public IActionResult GetBrandProduct(int id,string p,int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(pm.GetBrandProduct(id).Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var products = pm.GetBrandProduct(id).ToPagedList(page,10);
            return View(products);
        }
        public IActionResult SortIdOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(bm.List().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = bm.List().OrderBy(x=>x.Id).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult SortIdOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(bm.List().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = bm.List().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(bm.List().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = bm.List().OrderBy(x => x.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(bm.List().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = bm.List().OrderByDescending(x => x.Name).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortStatuOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(bm.List().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = bm.List().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortStatuOrderByDescending(string p,int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(bm.List().Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = bm.List().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }

    }
}
