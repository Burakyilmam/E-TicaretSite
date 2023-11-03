using Business.Concrete;
using DataAccess.Context;
using DataAccess.EntityFramework;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Security.Claims;
using X.PagedList;

namespace E_TicaretSite.Web.Controllers
{
    [Authorize]
    public class MainCategoryController : Controller
    {
        DataContext c = new DataContext();
        MainCategoryManager mcm = new MainCategoryManager(new EfMainCategoryRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult MainCategoryList(string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page,10));
            }
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = mcm.List().ToPagedList(page,10);
            return View(value);
        }
        [HttpGet]
        public IActionResult MainCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MainCategoryAdd(MainCategory mainCategory)
        {
            bool isMainCategoryExist = mcm.CheckMainCategoryName(mainCategory.MainCategoryName);
            if (!isMainCategoryExist)
            {
                mainCategory.Statu = true;
                mainCategory.CreatedDate = DateTime.Now;
                mcm.Add(mainCategory);
                return RedirectToAction("MainCategoryList", "MainCategory");
            }
            else
            {
                TempData["ErrorMessage"] = "Genel Kategori Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Genel Kategori Adı Yazınız.";
                return RedirectToAction("MainCategoryList");
            }
            
        }
        public IActionResult MainCategoryDelete(int id)
        {
            var value = mcm.Get(id);
            mcm.Delete(value);
            TempData["SuccessMessage"] = "Genel marka başarıyla silindi.";
            return RedirectToAction("MainCategoryList", "MainCategory");
        }

        [HttpGet]
        public IActionResult EditMainCategory(int id)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var value = mcm.Get(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditMainCategory(MainCategory mainCategory)
        {
            mcm.Update(mainCategory);
            return RedirectToAction("MainCategoryList", "MainCategory");
        }
        public IActionResult GetCategory(int id, string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(cm.GetCategory(id).Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            var categories = cm.GetCategory(id).ToPagedList(page,10);
            return View(categories);
        }

        public IActionResult SortIdOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = mcm.List().OrderBy(x => x.Id).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult SortIdOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = mcm.List().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = mcm.List().OrderBy(x => x.MainCategoryName).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortNameOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = mcm.List().OrderByDescending(x => x.MainCategoryName).ToPagedList(page, 10);
            return View(value);
        }
        public IActionResult SortStatuOrderBy(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = mcm.List().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
        public IActionResult SortStatuOrderByDescending(string p, int page = 1)
        {
            var user = c.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.UserName = User.Identity.Name;
            if (!string.IsNullOrEmpty(p))
            {
                return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
            }
            var value = mcm.List().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
            return View(value);
        }
    }
}
