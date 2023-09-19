using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Security.Claims;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        DataContext c = new DataContext();
        BrandManager bm = new BrandManager(new EfBrandRepository());
        public IActionResult BrandList()
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
            var value = bm.List();
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
            return RedirectToAction("BrandList", "Brand");
        }
        [HttpGet]
        public IActionResult EditBrand(int id)
        {
            var value = bm.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditBrand(Brand brand)
        {
            bm.Update(brand);
            return RedirectToAction("BrandList", "Brand");
        }
    }
}
