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
        public IActionResult MainCategoryList(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = mcm.List().ToPagedList(page, 10);
                    return View(value);
                }
            }
            return View();
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

                    var value = mcm.Get(id);
                    return View(value);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditMainCategory(MainCategory mainCategory)
        {
            mcm.Update(mainCategory);
            return RedirectToAction("MainCategoryList", "MainCategory");
        }
        public IActionResult GetCategory(int id, string p, int page = 1)
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


                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(cm.GetCategory(id).Where(x => x.Name.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var categories = cm.GetCategory(id).ToPagedList(page, 10);
                    return View(categories);
                }
            }
            return View();
        }
        public IActionResult SortIdOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = mcm.List().OrderBy(x => x.Id).ToPagedList(page, 10);
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortIdOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = mcm.List().OrderByDescending(x => x.Id).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortNameOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = mcm.List().OrderBy(x => x.MainCategoryName).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();

        }
        public IActionResult SortNameOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = mcm.List().OrderByDescending(x => x.MainCategoryName).ToPagedList(page, 10);
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortStatuOrderBy(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = mcm.List().OrderBy(x => x.Statu).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
        public IActionResult SortStatuOrderByDescending(string p, int page = 1)
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

                    if (!string.IsNullOrEmpty(p))
                    {
                        return View(mcm.List().Where(x => x.MainCategoryName.ToLower().Contains(p.ToLower())).ToPagedList(page, 10));
                    }
                    var value = mcm.List().OrderByDescending(x => x.Statu).ToPagedList(page, 10); ;
                    return View(value);
                }
            }
            return View();
        }
    }
}
