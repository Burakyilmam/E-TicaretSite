using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        BrandManager bm = new BrandManager(new EfBrandRepository());
        public IActionResult BrandList()
        {
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
            brand.Statu = true;
            brand.CreatedDate = DateTime.Now;
            bm.Add(brand);
            return RedirectToAction("BrandList", "Brand");
        }
    }
}
